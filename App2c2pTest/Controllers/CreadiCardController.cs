using System.Linq;
using System.Threading.Tasks;
using App2c2pTest.Extensions;
using App2c2pTest.Model;
using App2c2pTest.Repository.CreditCardRepo;
using Microsoft.AspNetCore.Mvc;

namespace App2c2pTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreadiCardController : ControllerBase
    {
        private readonly ICreditCardRepository _cardRepository;
       
        public CreadiCardController(ICreditCardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

     /// <summary>
     /// Validate Card
     /// </summary>
     /// <param name="card"></param>
     /// <returns></returns>
        [HttpPost("validate")]
        [ProducesResponseType(typeof(CardResponse), 200)]
        [ProducesResponseType(typeof(CardResponse), 200)]
        public async Task<ActionResult<CardResponse>> GetCard([FromBody]CreditCardsVm card)
        {
            if (ModelState.IsValid)
            {
                var year = card.ExpiryDate.Substring(2, 4).ToNumber();
                
                var sqlCardResult = await _cardRepository.GetCard(card.Card);
               

                if (sqlCardResult.Any())
                {

                    var processingResult = sqlCardResult.FirstOrDefault();
                    if (processingResult != null)
                    {
                       var  processingCard = processingResult.Card;
                        if (processingCard.IsValidVisaCard())
                        {
                            var response = new CardResponse {CardType = "Visa"};
                           
                            return Ok(response.ValidateVisaYear(year));
                        }
                        if (processingCard.IsValidMasterCard())
                        {
                            var response = new CardResponse {CardType = "Master"};

                            return Ok(response.ValidateIsMaterYearPrimeNumber(year));

                        }
                        if (processingCard.IsValidAmexCard())
                        {
                            var response = new CardResponse {CardType = "Amex"};
                            

                            return Ok(response.ValidateIsAmexCard15Digit(processingCard));
                        }
                        if (processingCard.IsValidJCBCard())
                        {
                            return Ok(new CardResponse {CardType = "JCB", Result = "Valid"});
                        }
                    }
                }
                else
                {
                    return Ok(new CardResponse {CardType = "Unknown", Result = "Does Not Exist"});
                }
              
            }
            return BadRequest(new CardResponse { CardType = "Unknown", Result = "Invalid" });
        }



    }
}
