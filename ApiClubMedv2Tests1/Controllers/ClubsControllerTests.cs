using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiClubMedv2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using ApiClubMedv2.Models.EntityFramework;
using ApiClubMedv2.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using ApiClubMedv2.Models.DataManager;

namespace ApiClubMedv2.Controllers.Tests
{
    [TestClass()]
    public class ClubsControllerTests
    {
        private DbContextOptionsBuilder<ClubMedDbContext> builder;
        private ClubMedDbContext context;
        private ClubsController controller;
        private IDataRepositoryJoin<Club> dataRepository;

        private Club clubAtester;
        private Club clubAtesterMoq;

        private Mock<IDataRepositoryJoin<Club>> mockRepository;
        private ClubsController mockController;

        public ClubsControllerTests()
        {
            builder = new DbContextOptionsBuilder<ClubMedDbContext>().UseNpgsql
                ("Server=iutannecy-deptinfo.fr;port=5432;Database=s401a2s3clubmed;uid=s223;password=2gBf9e;");
            context = new ClubMedDbContext(builder.Options);
            dataRepository = new ClubManager(context);
            controller = new ClubsController(dataRepository);

            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le Numen doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le Numen soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler
            // la méthode DELETE de l’API
            // ou remove du DbSet.

/*            clubAtester = new Club()
            {
                Nomenseignant = "MACHIN",
                Prenomenseignant = "Luc",
                Numen = "16E0412345ABC",
                Universite = "Universite de Grenoble",
                Datenaissance = new DateTime(1982, 01, 01),
            };*/

            // Arrange
            mockRepository = new Mock<IDataRepositoryJoin<Club>>();
            mockController = new ClubsController(mockRepository.Object);

           /* clubAtesterMoq = new Club()
            {
                EnseignantId = 1,
                Nomenseignant = "MACHIN",
                Prenomenseignant = "Luc",
                Numen = "16B0422875ADC",
                Universite = "Universite de Grenoble",
                Datenaissance = new DateTime(1984, 01, 01),
            };*/
        }

        private void VerifyModel<T>(Club user, Expression<Func<Club, T>> propertySelector, bool requered, string regexPattern, int maxLength, string errorMessage)
        {
            var regex = new Regex(regexPattern);
            var propertyValue = propertySelector.Compile()(user)?.ToString();

            if (requered && string.IsNullOrEmpty(propertyValue))
            {
                var propertyName = (propertySelector.Body as MemberExpression)?.Member.Name;
                controller.ModelState.AddModelError(propertyName, "Le " + propertyName + " est requis.");
            }
            else if (propertyValue?.Length > maxLength)
            {
                var propertyName = (propertySelector.Body as MemberExpression)?.Member.Name;
                controller.ModelState.AddModelError(propertyName, errorMessage);
            }
            else if (!string.IsNullOrEmpty(propertyValue) && !regex.IsMatch(propertyValue))
            {
                var propertyName = (propertySelector.Body as MemberExpression)?.Member.Name;
                controller.ModelState.AddModelError(propertyName, errorMessage);
            }
        }

/*        private void VerifyModel(Client user)
        {
            VerifyModel(user, u => u.Numen, false, @"^[A - Z0 - 9]{13}$", 13, "Le numen ne peut dépasser 13 caractères");
            VerifyModel(user, u => u.Universite, true, "", 50, "La longueur du nom de l'université ne doit pas dépasser 50 caractères");
            VerifyModel(user, u => u.Nomenseignant, false, "", 50, "Le nom ne doit pas dépasser 50 caractères");
            VerifyModel(user, u => u.Prenomenseignant, false, "", 50, "Le prenom ne doit pas dépasser 50 caractères");
        }*/

        [TestMethod()]
        public void ClubsControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetClubs()
        {
            var result = controller.GetClubs().Result.Value.ToList();// Act
            Thread.Sleep(1000);

            List<Club> utls = context.Clubs.ToList();

            /* Asserts */
            Assert.IsInstanceOfType(result, typeof(List<Club>), "Pas une liste de club"); // Test du type de retour
            CollectionAssert.AreEqual(result, utls, "Erreur lors du chargement des listes"); // Test du contenu du retour
        }

        [TestMethod()]
        public void GetClubByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetClubByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutClubTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostClubTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteClubTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetClubsByCountryTest()
        {
            Assert.Fail();
        }
    }
}