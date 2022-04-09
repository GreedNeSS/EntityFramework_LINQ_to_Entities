using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinAndGroupBy.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Title{ get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
