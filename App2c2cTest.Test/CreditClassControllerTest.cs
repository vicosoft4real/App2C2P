using System.Threading.Tasks;
using App2c2pTest.Controllers;
using App2c2pTest.Data.Entites;
using App2c2pTest.Model;
using App2c2pTest.Repository.CreditCardRepo;
using App2c2pTest.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace App2c2cTest.Test
{
    [TestClass]
    public class CreditClassControllerTest
    {
       

        private Mock<IRepository<CreditCard>> _respositoryMock = new Mock<IRepository<CreditCard>>();
        private readonly Mock<ICreditCardRepository> _creditCardRepository = new Mock<ICreditCardRepository>(_respositoryMock.);

        private readonly CreadiCardController _cardController;
        

        public CreditClassControllerTest()
        {
            _cardController = new CreadiCardController(_creditCardRepository.Object);
        }
        [TestMethod]
        public async Task TestCard_is_Valid_Visa_Card()
        {
            //arrange 
            var card = new CreditCardsVm
            {
                Card = "4123-8929-9323-8923",
                ExpiryDate = 012019
            };
            //act
            var result = await _cardController.GetCard(card);

            //assert

            Assert.IsNotNull(result);

        }
    }
   
}
