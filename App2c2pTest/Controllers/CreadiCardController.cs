using System;
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
                var year = card.ExpiryDate.ToString().Substring(2, 4).ToNumber();
                
                var sqlCardResult = await _cardRepository.GetCard(card.Card);
               

                if (sqlCardResult.Any())
                {

                    var processingResult = sqlCardResult.FirstOrDefault();
                    if (processingResult != null)
                    {
                       var  processingCard = processingResult.Card;
                        return Validate(processingCard,year);                    }
                }
                
              
            }
            return BadRequest(card.Card.SetCard("Unknown").SetResult("Does Not Exist"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processingCard"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private ActionResult<CardResponse> Validate(string processingCard, int year)
        {
            if (processingCard.IsValidVisaCard())
            {
                var response = processingCard.SetCard("Visa");
                return Ok(response.ValidateVisaYear(year));
            }
           else if (processingCard.IsValidMasterCard())
            {

                var response = processingCard.SetCard("Master");

                return Ok(response.ValidateIsMaterYearPrimeNumber(year));

            }
           else if (processingCard.IsValidAmexCard())
            {
                var response = processingCard.SetCard("Amex");


                return Ok(response.ValidateIsAmexCard15Digit(processingCard));
            }
            else if(processingCard.IsValidJCBCard())
            {
                return Ok(processingCard.SetCard("JCB").SetResult("Valid"));
            }

            return Ok(processingCard.SetCard("Unknown").SetResult("Invalid" ));
        }
    }
}
