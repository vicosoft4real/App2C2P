using System.ComponentModel.DataAnnotations;

namespace App2c2pTest.Model
{
    public class CreditCardsVm
    {
        [Required(ErrorMessage = "The Card to be validated is required", AllowEmptyStrings = false)]
        [StringLength(19, MinimumLength =19)]
        public string Card { get; set; }

        [Required(ErrorMessage = "You must specify expiry date", AllowEmptyStrings =false)]
       // [RegularExpression("/^([0-9]{6})/", ErrorMessage = "Invalid Expiry Date")]
        [CustomeDateLengthValidationAttributes(6, MinimumLength = 6, ErrorMessage ="The date must be within 6 digits, e.g 081990")]
        public string ExpiryDate { get; set; }
    }


    public class CustomeDateLengthValidationAttributes : StringLengthAttribute
    {
        public CustomeDateLengthValidationAttributes(int maximumLength):base(maximumLength)
        {

        }
        public override bool IsValid(object value)
        {
            string val = value.ToString();
             if(val.Length != 6)
            {
                base.ErrorMessage = "Date length should be 6 digits, Format : 061980";
                return false;          }

            return base.IsValid(value);
        }

    }
}
