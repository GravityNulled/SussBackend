using ChallengeSuss.Models;
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
        private readonly List<Service> _services = new()
        {
            new Service {
                Id = 1,
                Name = "Ads Service",
                Description = "Best Ads in the market",
            },
            new Service {
                Id = 2,
                Name = "Sms Service",
                Description = "Send Sms to clients directly",
            },
        };
        public CampaignRepository()
        {
            _campaigns = new List<Campaign>()
            {
                new Campaign
                {
                    CampaignId = 1,
                    Name="Ads Campaign",
                    StartDate= new DateTime(2023, 7, 31),
                    EndDate= new DateTime(2023, 8, 31),
                    serviceId = 1,
                },
                new Campaign
                {
                    CampaignId = 2,
                    Name="Sms Campaign",
                    StartDate= new DateTime(2023, 7, 31),
                    EndDate= new DateTime(2023, 8, 31),
                    serviceId = 2,
                },
            };
        }

        public Campaign Create(Campaign campaign)
        {
            var checkService = _services.Find(x => x.Id == campaign.serviceId);
            campaign.CampaignId = _campaigns.Max(x => x.CampaignId) + 1;
            if (checkService == null)
            {
                return null;
            }
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
                entity.serviceId = campaign.serviceId;
                entity.StartDate = campaign.StartDate;
                entity.EndDate = campaign.EndDate;
                return true;
            }
            return false;
        }
    }
}
