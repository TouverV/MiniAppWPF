using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    public class Claim
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Equipment { get; set; }
        public string IssueType { get; set; }
        public string Status { get; set; }
        public string Client { get; set; }
    }
}
