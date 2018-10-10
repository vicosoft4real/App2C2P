using System.Threading.Tasks;
using App2c2pTest.Controllers;
using App2c2pTest.Model;
using App2c2pTest.Repository.AutoFacModule;
using App2c2pTest.Repository.CreditCardRepo;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CreditCardTests
{
    [TestClass]
    public class CreditCardControllerTest
    {
        public IContainer ApplicationContainer { get; private set; }

        [TestInitialize]
        public void StartUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RepositoryModule>();
            ApplicationContainer = builder.Build();
        }
        [TestMethod]
        public void TestMethod1()
        {

            //arrange 
            ApplicationContainer.Resolve<ICreditCardRepository>();
           
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                mock.Mock<ICreditCardRepository>();
                var repo = mock.Create<CreadiCardController>();


                var creditCards = new CreditCardsVm
                {
                    Card = "4909-2832-8723-8888",
                    ExpiryDate = "081980"
                };



                // Act
                var result = repo.GetCard(creditCards);

                // Assert
                Assert.IsNotNull(result);


            }
           
            
        }
    }
}
