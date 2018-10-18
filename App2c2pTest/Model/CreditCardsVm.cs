using System.ComponentModel.DataAnnotations;

namespace App2c2pTest.Model
{
    public class CreditCardsVm
    {
        [Required(ErrorMessage = "The Card to be validated is required", AllowEmptyStrings = false)]
        [StringLength(19)]
        public string Card { get; set; }

        [Required(ErrorMessage = "You must specify expiry date")]
        [RegularExpression("/^([0-9]{6})/g", ErrorMessage = "Invalid Expiry Date")]
        public int ExpiryDate { get; set; }
    }
}
