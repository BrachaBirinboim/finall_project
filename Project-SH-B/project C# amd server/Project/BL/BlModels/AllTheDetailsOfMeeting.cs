using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlModels
{
    public class AllTheDetailsOfMeeting
    {
     

        public string DieticanFirstName { get; set; }
        public string DieticanLastName { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Status { get; set; }
        public TimeSpan Hour { get; set; }
        public DateTime Date { get; set; }

       
    }
}
