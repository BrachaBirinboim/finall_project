using Bl.BlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface IBlDietitianService:Icrud<FullDietitian>
    {
        public List<MeetingForDietitian> GetTodatMeetingsById(int Id);
        List<BlDietitian> GetAll();
        int Delete(int Id);


    }
}
