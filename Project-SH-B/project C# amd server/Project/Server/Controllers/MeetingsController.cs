using Bl;
using Bl.BlApi;
using Bl.BlModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        IBlMeetingService BlMeetingService;
        public MeetingsController(BlManager instance)
        {
            this.BlMeetingService = instance.Meetings;
        }
        [HttpGet]
        public List<AllTheDetailsOfMeeting> GetAll()
        {
            return BlMeetingService.GetAllMeetings();
        }
        [HttpPut("{meetingStatus}")]
        public ActionResult<AllTheDetailsOfMeeting> SetMeetingStatus(General_meeting_details general_Meeting_Details, string meetingStatus)
        {

            return BlMeetingService.SetMeetingStatus(general_Meeting_Details, meetingStatus);
        }
        [HttpPost]
        public ActionResult<Meeting> AddMeeting(Meeting meeting)
        {

            return BlMeetingService.Add(meeting);
        }
        

    }
}
