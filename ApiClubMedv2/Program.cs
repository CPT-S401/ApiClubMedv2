using ApiClubMedv2.Models.DataManager;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiClubMedv2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IDataRepository<Club>, ClubManager>();
            builder.Services.AddScoped<IDataRepository<TypeClub>, TypeClubManager>();
            builder.Services.AddScoped<IDataRepository<TypeChambre>, TypeChambreManager>();
            builder.Services.AddScoped<IDataRepository<DomaineSkiable>, DomaineSkiableManager>();
            builder.Services.AddScoped<IDataRepository<Multimedia>, MultimediaManager>();
            builder.Services.AddScoped<IDataRepository<Transport>, TransportManager>();
            builder.Services.AddScoped<IDataRepository<Caracteristique>, CaracteristiqueManager>();
            builder.Services.AddScoped<IDataRepository<Cookie>, CookieManager>();
            builder.Services.AddScoped<IDataRepository<Activite>, ActiviteManager>();
            builder.Services.AddScoped<IDataRepository<ActiviteEnfant>, ActiviteEnfantManager>();
            builder.Services.AddScoped<IDataRepository<TypeActivite>, TypeActiviteManager>();
            builder.Services.AddScoped<IDataRepository<Bar>, BarManager>();
            builder.Services.AddScoped<IDataRepository<Restaurant>, RestaurantManager>();
            builder.Services.AddScoped<IDataRepository<Ville>, VilleManager>();
            builder.Services.AddScoped<IDataRepository<Pays>, PaysManager>();
            builder.Services.AddScoped<IDataRepository<CodePostal>, CodePostalManager>();
            builder.Services.AddScoped<IDataRepository<Localisation>, LocalisationManager>();
            builder.Services.AddScoped<IDataRepository<Reservation>, ReservationManager>();
            builder.Services.AddScoped<IDataRepository<Avis>, AvisManager>();

            // Add controllers to the container
            builder.Services.AddControllers();

            // Connect to database with the string in appsettings.json
            builder.Services.AddDbContext<ClubMedDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ClubMedDBContext")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                     };
                });

            builder.Services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.UserPolicy());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
                // app.UseMigrationsEndPoint();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ClubMedDbContext>();
                context.Database.EnsureCreated();
                // DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseCors(options =>
            {
                options.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials();
            });

            app.MapControllers();

            app.Run();

        }
    }
}