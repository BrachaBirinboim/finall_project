using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IMeetingService:Icrud<Meeting>
    {
      
        public Meeting SetMeetingStatus(Meeting meeting,string meetingStatus);
        public List<QueuesForDietitian> GetAllQueues();
        public void SetAvailableStatus(Meeting meeting);

    }
}
