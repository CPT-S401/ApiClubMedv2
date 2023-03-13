using ApiClubMedv2.Models.DataManager;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.EntityFrameworkCore;

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


            // Add controllers to the container
            builder.Services.AddControllers();

            // Connect to database with the string in appsettings.json
            builder.Services.AddDbContext<ClubMedDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ClubMedDBContext")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}