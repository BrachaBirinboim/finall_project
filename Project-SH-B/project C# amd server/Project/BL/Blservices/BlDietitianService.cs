using Dal.DalApi;
using Dal.Services;
using Dal.Models;
using Bl.Blservices;
using Bl.BlApi;
using Dal;
using Bl.BlModels;
using AutoMapper;

namespace Bl.Blservices
{

    public class BlDietitianService: IBlDietitianService
    {
        IDietitianService dietitianService;
        IMeetingService meetingService;
        IMapper map;
        public BlDietitianService(DalManager instance, IMapper myMap)
        {
            this.dietitianService =instance.Dietitians;
            this.meetingService = instance.Meetings;
            map = myMap;
        }

        #region get functions
     

        public List<BlDietitian> GetAll()
        {
            List<BlDietitian> blDietitians = new List<BlDietitian>();
            var list = dietitianService.GetAll();
            list.ForEach(d => blDietitians.Add(map.Map<Bl.BlModels.BlDietitian>(d)));
            return blDietitians;


        }
        List<MeetingForDietitian> IBlDietitianService.GetTodatMeetingsById(int Id)
        {
            List<BlModels.MeetingForDietitian> meetings = new List<BlModels.MeetingForDietitian>();
            var list = dietitianService.GetMeetingsById(Id).Where(d => d.Date == DateTime.Today).ToList();
            List<BlModels.Dietitian> dietitians = new List<BlModels.Dietitian>();

            list.ForEach(m => meetings.Add(new BlModels.MeetingForDietitian() { FirstName = m.Client.FirstName, LastName = m.Client.LastName, Age = DateTime.Now.Year - m.Client.BirthDate.Year, Hour = m.Hour, Phone = m.Client.Phone }));
            return meetings;
        }


        #endregion get functions

        #region add functions

        public FullDietitian Add(FullDietitian dietitian)
        {
            //Dal.Models.Dietitian dietitian1 = map.Map<Dal.Models.Dietitian>(dietitian);
            Dal.Models.Dietitian dietitian1 =new Dal.Models.Dietitian() { Id=dietitian.Id,Email=dietitian.Email,FirstName=dietitian.FirstName,Kind=dietitian.Kind,Phone=dietitian.Phone,LastName=dietitian.LastName};
            int dietitianId = dietitianService.Add(dietitian1).Id;
            List<Dal.Models.WorkHour> hours = new List<Dal.Models.WorkHour>();
            dietitian.WorkHours.ForEach(h => hours.Add(new Dal.Models.WorkHour() { DieticanId = dietitianId, StartHour = h.StartHour, EndHour = h.EndHour, DayInTheWeek = h.DayInTheWeek }));
            dietitianService.AddHours(hours);
            List<QueuesForDietitian> queues=new List<QueuesForDietitian>();
            DateTime dalStartTime = DateTime.Now;
            int i=0;
            for (DateTime d = dalStartTime.AddDays(1); i<365; d=d.AddDays(1), i++)
            {
                int day;
                day = (int)d.DayOfWeek;
                Dal.Models.WorkHour work;
                work = hours.FirstOrDefault(h => h.DayInTheWeek == day);
                if (work != null)
                {
                    TimeSpan t1 = TimeSpan.FromHours(0.5);
                    for (TimeSpan t = work.StartHour; t < work.EndHour; t=t.Add(t1))
                    {
                        queues.Add(new QueuesForDietitian() { Available = true, Date = d, DieticanId = dietitianId, Hour = t });
                    }
                }


            }


            dietitianService.AddQueues(queues);
            return dietitian;
        }

        public int Delete(int id)
        {
            Dal.Models.Meeting meeting = new();
            meeting=meetingService.GetAll().Where(c=>c.Status=="invited").FirstOrDefault(c=>c.DieticanId==id);
            if (meeting==null)
            {
              return  dietitianService.Delete(id);
            }
            else
            {
                throw new NotImplementedException("You can't delete this dietitian");
            }

        }

        public BlModels.Dietitian Add(BlModels.Dietitian obg)
        {
            throw new NotImplementedException();
        }



        #endregion add functions





        //public int Delete(Dietitian dietitian)
        //{
        //    nutritionContext.Dietitians.Remove(dietitian);
        //    nutritionContext.SaveChanges();
        //    return dietitian.Id;
        //}







        //public Dietitian Update(Dietitian dietitian, int id)
        //{
        //    Dietitian dietitian1 = nutritionContext.Dietitians.FirstOrDefault(d => d.Id == id);
        //    dietitian1.Email = dietitian.Email;
        //    dietitian1.FirstName = dietitian.FirstName;
        //    dietitian1.LastName = dietitian.LastName;
        //    dietitian1.Phone = dietitian.Phone;
        //    nutritionContext.SaveChanges();
        //    return dietitian;
        //}
    }
}

