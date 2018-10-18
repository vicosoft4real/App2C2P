using System.Threading.Tasks;
using App2c2pTest.Controllers;
using App2c2pTest.Data;
using App2c2pTest.Model;
using App2c2pTest.Repository.AutoFacModule;
using App2c2pTest.Repository.CreditCardRepo;
using Autofac;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace App2c2cTest.Tests
{
    [TestFixture]
    public class CreditCardControllerTest
    {


        private CreadiCardController _creditCardController;
        public IContainer ApplicationContainer { get; private set; }

        [OneTimeSetUp]
        public void Init()
        {
            var optionsBuilder = new DbContextOptionsBuilder<App2c2pContext>();
            optionsBuilder.UseSqlServer("Server=L-TAKINOLA2\\MSSQLSERVER2012; Database=App2c2pDb;User ID=sa;Password=qwerty;MultipleActiveResultSets=true;");


            var builder = new ContainerBuilder();

            builder.Register(c => new App2c2pContext(optionsBuilder.Options));

            builder.RegisterModule<RepositoryModule>();
            ApplicationContainer = builder.Build();

            var repo = ApplicationContainer.Resolve<ICreditCardRepository>();

            _creditCardController = new CreadiCardController(repo);
        }





        [Test]
        public async Task Post_CheckValid_Visa_Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "4909-2832-8723-8888",
                ExpiryDate = "081980"
            };



            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Visa", cardResponse.CardType);
            Assert.AreEqual("Valid", cardResponse.Result);
        }


        [Test]
        public async Task Post_CheckValid_Visa_Card_ivalid_ExipireYear()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "4909-2832-8723-8888",
                ExpiryDate = "081981"
            };



            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Visa", cardResponse.CardType);
            Assert.AreEqual("InValid", cardResponse.Result);
        }


        [Test]
        public async Task Post_CheckValid_Master_Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "5909-2222-8723-8888",
                ExpiryDate = "081913"
            };



            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Master", cardResponse.CardType);
            Assert.AreEqual("Valid", cardResponse.Result);
        }

        [Test]
        public async Task Post_CheckValid_Master_Card_Ivalid_ExipredYear()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "5909-2222-8723-8888",
                ExpiryDate = "082020"
            };



            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Master", cardResponse.CardType);
            Assert.AreEqual("InValid", cardResponse.Result);
        }

        [Test]
        public async Task Post_CheckValid_Amex_Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "3409-2222-8723-888",
                ExpiryDate = "081913"
            };


            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Amex", cardResponse.CardType);
            Assert.AreEqual("Valid", cardResponse.Result);
        }
        [Test]
        public async Task Post_InValid_Amex_Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "3709-2222-8723-8888",
                ExpiryDate = "081913"
            };


            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Amex", cardResponse.CardType);
            Assert.AreEqual("InValid", cardResponse.Result);
        }


        [Test]
        public async Task Post_CheckValid_JCB_Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "3528-3589-8723-8888",
                ExpiryDate = "081913"
            };


            // Act
            var result = await _creditCardController.GetCard(creditCards);
            var value = result.Result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("JCB", cardResponse.CardType);
            Assert.AreEqual("Valid", cardResponse.Result);
        }
        [Test]
        public async Task Post_Unknown_DoesNot_Exist__Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "35283589-8723-8888",
                ExpiryDate = "081913"
            };


            // Act
            var result = await _creditCardController.GetCard(creditCards);

            var value = result.Result as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Unknown", cardResponse.CardType);
            Assert.AreEqual("Does Not Exist", cardResponse.Result);
        }

        [Test]
        public async Task Post_Unknown_Invalid__Card()
        {
            // Arrange
            var creditCards = new CreditCardsVm
            {
                Card = "3528-3589-8723-8888",
                ExpiryDate = "0819139"
            };


            // Act
            var result = await _creditCardController.GetCard(creditCards);

            var value = result.Result as Microsoft.AspNetCore.Mvc.BadRequestObjectResult;
            Assert.NotNull(value);
            var cardResponse = value.Value as CardResponse;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(cardResponse);
            Assert.AreEqual("Unknown", cardResponse.CardType);
            Assert.AreEqual("Invalid", cardResponse.Result);
        }


    }
}
