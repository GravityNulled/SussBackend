using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suss.Domain
{
    public class Campaign
    {
        [Required]
        [Key]
        public int CampaignId { get; set; }
        [Required]

        [StringLength(50)]
        public required string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
        [Required]
        public List<string> Products { get; set; } = new List<string>();
    }
}
