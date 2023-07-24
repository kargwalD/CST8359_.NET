using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Fan")]
        public int FanId { get; set; }

        [ForeignKey("SportClub")]
        public string SportClubId { get; set; }

        public Fan Fan { get; set; }

        public SportClub SportClub { get; set; }
    }
}
