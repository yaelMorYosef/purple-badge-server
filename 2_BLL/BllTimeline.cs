using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL;
using DTO;

namespace _2_BLL
{
    public class BllTimeline
    {
        public List<DtoTimeline> GetAllBllTimeFromBll()
        {
            DalTimeline daltimeL = new DalTimeline();
            List<DtoTimeline> dtoTimeLine = new List<DtoTimeline>();
            List<Timeline> t = daltimeL.GetAllTimeLineFromDal();
            foreach (Timeline currentTimeL in t)
            {
                dtoTimeLine.Add(Converters.Converters.ConvertTimeLineToDTO(currentTimeL));
            }
            return dtoTimeLine;
        }

        public DtoTimeline AddTimeLineToBLL(DtoTimeline t)
        {
            DalTimeline tl = new DalTimeline();
            return Converters.Converters.ConvertTimeLineToDTO
                (tl.addTimeLineToSQL(Converters.Converters.ConvertTimeLineDAL(t)));
        }

        public DtoTimeline updateTimeLineToBLL(DtoTimeline t)
        {
            DalTimeline tl = new DalTimeline();
            return Converters.Converters.ConvertTimeLineToDTO
                (tl.updateTimeLineToSQL(Converters.Converters.ConvertTimeLineDAL(t)));
        }
    }
}
