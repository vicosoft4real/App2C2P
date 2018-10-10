using System.ComponentModel.DataAnnotations;

namespace App2c2pTest.Data.Entites
{
    public class CreditCard: EntityBase
    {
        [StringLength(19)]
        [Required]
        public string Card { get; set; }
        public string CardDescription { get; set; }
        [Required]
        [MaxLength(6)]
        public int ExpiryDate { get; set; }

    }
}
