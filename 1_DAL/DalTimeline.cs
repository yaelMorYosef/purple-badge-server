using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL
{
    public class DalTimeline
    {

        public List<Timeline> GetAllTimeLineFromDal()
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                List<Timeline> timeLineList = db.Timelines.ToList();
                return timeLineList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Timeline addTimeLineToSQL(Timeline timeline)
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();

                db.Timelines.Add(timeline);
                db.SaveChanges();
                return timeline;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Timeline updateTimeLineToSQL(Timeline timeline)
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();

                var result = db.Timelines.Find(timeline);
                if (result == null)
                {
                    return null;
                }
                if (result != null)
                    result.exitTime = DateTime.Today;

                db.SaveChanges();
                return timeline;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

