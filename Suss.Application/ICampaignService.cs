using Suss.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suss.Application
{
    public interface ICampaignService
    {
        IEnumerable<Campaign> GetAll(int page, int pageSize);
        Campaign GetById(int id);
        Campaign Create(Campaign campaign);
        bool Update(int id, Campaign campaign);
        bool Delete(int id);
    }
}
