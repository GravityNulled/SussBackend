using Suss.Application;
using Suss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suss.Infrastructure
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly List<Campaign> _campaigns;
        public CampaignRepository()
        {
            _campaigns = new List<Campaign>()
            {
                new Campaign
                    {
                CampaignId=1,
                Name="Ads Campaign",
                StartDate= new DateTime(2023, 7, 31),
                EndDate= new DateTime(2023, 8, 31),
                Products = new List<string>
                {
                   "Ads1",
                   "Ads2"
                }
                    },
                 new Campaign
            {
                CampaignId=2,
                Name="Sms Campaign",
                StartDate= new DateTime(2023, 7, 31),
                EndDate= new DateTime(2023, 8, 31),
                Products = new List<string>
                {
                   "sms1",
                   "sms2"
                }
            },
            };
        }

        public Campaign Create(Campaign campaign)
        {
            _campaigns.Add(campaign);
            return campaign;
        }

        public bool Delete(int id)
        {
            var entity = _campaigns.Find(c => c.CampaignId == id);

            if (entity is not null)
            {
                _campaigns.Remove(entity);
                return true;
            }
            return false;
        }

        public IEnumerable<Campaign> GetAll(int page, int pageSize)
        {
            var totalCampaigns = _campaigns.Count;
            var totalPages = (int)Math.Ceiling((decimal)totalCampaigns / pageSize);
            var campaignsPerPage = _campaigns.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return campaignsPerPage;
        }

        public Campaign GetById(int id)
        {
            return _campaigns.FirstOrDefault(c => c.CampaignId == id);
        }

        public bool Update(int id, Campaign campaign)
        {
            var entity = _campaigns.FirstOrDefault(c => c.CampaignId == id);
            if (entity is not null)
            {
                entity.Products = campaign.Products;
                entity.StartDate = campaign.StartDate;
                entity.EndDate = campaign.EndDate;
                return true;
            }
            return false;
        }
    }
}
