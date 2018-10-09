using System.Collections.Generic;
using System.Threading.Tasks;
using App2c2pTest.Data.Entites;
using NACC.Repository.Interface;

namespace App2c2pTest.Repository.CreditCardRepo
{
    public interface ICreditCardRepository:IAutoDependencyRegister
    {
        Task<List<CreditCard>> GetCard(string card);
    }
}