using Suss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suss.Application
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public Campaign Create(Campaign campaign)
        {
            _campaignRepository.Create(campaign);
            return campaign;
        }

        public bool Delete(int id)
        {
            var deleted =  _campaignRepository.Delete(id);
            return deleted;
        }

        public IEnumerable<Campaign> GetAll(int page, int pageSize)
        {
            var campigns = _campaignRepository.GetAll(page, pageSize);
            return campigns;
        }

        public Campaign GetById(int id)
        {
           var campaign = _campaignRepository.GetById(id);
            return campaign;
        }

        public bool Update(int id, Campaign campaign)
        {
           var updated = _campaignRepository.Update(id, campaign);
           return updated;
        }
    }
}
