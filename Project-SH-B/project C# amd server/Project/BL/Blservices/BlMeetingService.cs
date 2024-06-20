using AutoMapper;
using Bl.BlApi;
using Bl.BlModels;
using Dal;
using Dal.DalApi;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Blservices
{
    public class BlMeetingService : IBlMeetingService
    {
        IMeetingService meetingService;
        IMapper mapper;
        public BlMeetingService(DalManager dalManager, IMapper mapper)
        {
            this.meetingService = (IMeetingService)dalManager.Meetings;
            this.mapper = mapper;
        }





        public BlModels.Meeting Add(BlModels.Meeting meeting)
        {
            Dal.Models.Meeting meeting1 = mapper.Map<Dal.Models.Meeting>(meeting);

            meetingService.Add(meeting1);
            meetingService.SetAvailableStatus(meeting1);
            return meeting;
        }

        //public Meeting Add(AllTheDetailsOfMeeting obg)
        //{
        //   Meeting meeting = new Meeting();
        //    meeting.Status = obg.Status;
        //    meeting.Date = obg.Date;
        //    meeting.ClientId = obg.ClientId;
        //    meeting.DieticanId = obg.DieticanId;
        //    meeting.Hour = obg.Hour;

        //    meetingService.Add(meeting);
        //    return meeting;

        //}

        //public AllTheDetailsOfMeeting Add(BlModels.Meeting.Meeting obg)
        //{

        //}

        public List<AllTheDetailsOfMeeting> GetAllMeetings()
        {
            List<AllTheDetailsOfMeeting> BlList = new List<AllTheDetailsOfMeeting>();
            var list = meetingService.GetAll();
            list.ForEach(m => BlList.Add(mapper.Map<Bl.BlModels.AllTheDetailsOfMeeting>(m)));
            return BlList;
        }

        public List<BlQueuesForDietitian> GetAllQueues()
        {
            List<BlQueuesForDietitian> blQueues = new List<BlQueuesForDietitian>();
            var q = meetingService.GetAllQueues().Where(q => q.Available == true && q.Date > DateTime.Now).ToList();
            q.ForEach(q => blQueues.Add(mapper.Map<BlQueuesForDietitian>(q)));
            return blQueues;
        }
        public List<BlQueuesForDietitian> GetQueuesById(int id)
        {
            List<BlQueuesForDietitian> blQueues = GetAllQueues().Where(q => q.DieticanId == id).ToList();
            return blQueues;

        }



        //public List<AllTheDetailsOfMeeting> GetAllQueues()
        //{
        //    List<QueuesForDietitian> BlList = new List<QueuesForDietitian>();
        //    var list = meetingService.GetAll();
        //    list.ForEach(m => BlList.Add(mapper.Map<Bl.BlModels.AllTheDetailsOfMeeting>(m)));
        //    return BlList;
        //}

        //public AllTheDetailsOfMeeting SetMeetingsAsExist(General_meeting_details meeting_details)
        //{
        //    Dal.Models.Meeting meeting = meetingService.GetAll().Find(m => (m.DieticanId == meeting_details.DieticanId && m.ClientId == meeting_details.ClientId && m.Date == meeting_details.Date));

        //    if (meeting != null)
        //    {
        //       return mapper.Map<AllTheDetailsOfMeeting>(meetingService.SetMeetingsAsExist(meeting));

        //    }
        //    return null;

        //}
        public AllTheDetailsOfMeeting SetMeetingStatus(General_meeting_details meeting_details, string meetingStatus)
        {
            Dal.Models.Meeting meeting = meetingService.GetAll().Find(m => (m.DieticanId == meeting_details.DieticanId && m.ClientId == meeting_details.ClientId && m.Date == meeting_details.Date));

            if (meeting != null)
            {
                return mapper.Map<AllTheDetailsOfMeeting>(meetingService.SetMeetingStatus(meeting, meetingStatus));

            }
            return null;

        }








    }
}

