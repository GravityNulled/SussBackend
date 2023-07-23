using Microsoft.AspNetCore.Mvc;
using Suss.Application;
using Suss.Domain;
using Suss.Infrastructure;

namespace Suss.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public ActionResult Get(int page = 1, int pagesize = 20)
        {
            var campaigns = _campaignService.GetAll(page, pagesize);
            return Ok(campaigns);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var campaign = _campaignService.GetById(id);
                if (campaign is not null)
                {
                    return Ok(campaign);
                }
                return NotFound("Resource not found.");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<Campaign> Post([FromBody] Campaign campaign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkDates = CompareDates(campaign.StartDate, campaign.EndDate);
                    if (checkDates)
                    {
                        var entity = _campaignService.Create(campaign);
                        return CreatedAtAction("GetById", new { id = entity.CampaignId }, entity);
                    }
                    return BadRequest("Invalid input data. Please check the provided information.");

                }
                return BadRequest("Invalid request. Please provide all required parameters.");
            }
            catch (Exception)
            {

                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Campaign campaign)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var checkDates = CompareDates(campaign.StartDate, campaign.EndDate);
                    if (checkDates)
                    {
                        var isUpdated = _campaignService.Update(id, campaign);
                        if (isUpdated)
                        {
                            return NoContent();
                        }
                        return NotFound("Resource not found.");
                    }
                    return BadRequest("Invalid input data. Please check the provided information.");
                }
                return BadRequest("Invalid request. Please provide all required parameters.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            try
            {
                var deleted = _campaignService.Delete(id);

                if (deleted)
                {
                    return NoContent();
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [NonAction]
        private bool CompareDates(DateTime startDate, DateTime EndDate)
        {
            if (EndDate > startDate) return true;
            return false;
        }

    }
}
