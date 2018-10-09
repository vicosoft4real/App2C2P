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
        [HttpGet("validate")]
        [ProducesResponseType(typeof(CardResponse), 200)]
        public async Task<ActionResult<CardResponse>> GetCard(CreditCardsVm card)
        {
            if (ModelState.IsValid)
            {
                var sqlCardResult = await Task.FromResult(_cardRepository.GetCard(card.Card).FirstOrDefault());
                var year = card.ExpiryDate.ToString().Substring(1,5).ToNumber();

                if (sqlCardResult != null)
                {
                    var processingCard = sqlCardResult.Card;

                    if (processingCard.IsValidVisaCard() && year.IsExpiryDateLeadYear())
                    {
                        return Ok(new CardResponse {CardType = "Visa", Result = "Valid"});
                    }
                    if (processingCard.IsValidMasterCard() && year.IsPrime())
                    {
                        return Ok(new CardResponse {CardType = "Master", Result = "Valid"});

                    }
                    if (processingCard.IsValidAmexCard() && processingCard.IsCard15Digita())
                    {
                        return Ok(new CardResponse {CardType = "Amex", Result = "Valid"});
                    }
                    if (processingCard.IsValidJCBCard())
                    {
                        return Ok(new CardResponse {CardType = "JCB", Result = "Valid"});
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
