
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using App2c2pTest.Data;
using App2c2pTest.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace App2c2pTest.Repository.CreditCardRepo
{
    public class CreditCardRepository : ICreditCardRepository
    {
        public readonly App2c2pContext _creditCardRepository;

        public CreditCardRepository(App2c2pContext creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public  async Task<List<CreditCard>> GetCard(string card)
        {
            var param = new SqlParameter("@card", card);
            return  await _creditCardRepository.CreditCards.FromSql($"GetCard @card", param).ToListAsync();
           
        } 
    }
}
