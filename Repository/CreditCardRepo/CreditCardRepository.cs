
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App2c2pTest.Data.Entites;
using App2c2pTest.Repository.Interface;

namespace App2c2pTest.Repository.CreditCardRepo
{
    public class CreditCardRepository : ICreditCardRepository
    {
        public readonly IRepository<CreditCard> _creditCardRepository;
        public CreditCardRepository(IRepository<CreditCard> creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public  List<CreditCard> GetCard(string card)
        {
            return  _creditCardRepository.ExecuteTSQL($"GetCard {card} ");
           
        } 
    }
}
