using System.ComponentModel.DataAnnotations;

namespace App2c2pTest.Data.Entites
{
    public class CreditCard: EntityBase
    {
        [StringLength(16)]
        public string Card { get; set; }
        public string CardDescription { get; set; }
        [MaxLength(6)]
        public int ExpiryDate { get; set; }

    }
}
