using Bl.BlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IBlMeetingService : Icrud<Meeting>
    {
        public AllTheDetailsOfMeeting SetMeetingStatus(General_meeting_details general_Meeting_Details, string meetingStatus);
        public List<AllTheDetailsOfMeeting> GetAllMeetings();

        public List<BlQueuesForDietitian> GetAllQueues();
        public List<BlQueuesForDietitian> GetQueuesById(int dietitianId);
    }
}
