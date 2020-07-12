using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
using _2_BLL;

namespace YYPB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]


    public class TimelineController : ApiController
    {


        private BllTimeline myBllTimeLine = new BllTimeline();
        private List<DtoTimeline> listTimeLines;


        [HttpGet]
        public List<DtoTimeline> GetTmeLineByBusinessId(int businessId)
        {

            listTimeLines = myBllTimeLine.GetAllBllTimeFromBll();
            List<DtoTimeline> l = new List<DtoTimeline>();
            foreach (DtoTimeline item in listTimeLines)
            {
                if (item.businessID == businessId)
                    l.Add(item);
            }
            return l;
        }
        [HttpGet]
        public List<DtoTimeline> GetAllTimeLines()
        {
            List<DtoTimeline> tl =
                 myBllTimeLine.GetAllBllTimeFromBll();

            return tl;
        }
        //פונקציה המחזירה את רשימת העסקים של מנהל
        [HttpGet]
        public List<DtoTimeline> GetTimeLineByBusinessId(string businessID)
        {

            return myBllTimeLine.GetAllBllTimeFromBll().Where(e => e.businessID == Convert.ToInt32(businessID)).ToList();
        }
        //רשימת אנשים עכשיו בחנות
        [HttpGet]
        public List<DtoTimeline> GetCustomersNowByBusinessId(string businessID)
        {
            DateTime d = DateTime.Today;
            //כל האנשים שנכנסו היום שלא יצאו
            return myBllTimeLine.GetAllBllTimeFromBll().Where(e => e.businessID == Convert.ToInt32(businessID) && e.exitTime == null &&e.entranceDate==d).ToList();
        }
        /*   [HttpPost]
            public DtoBusiness GetIfBusinessExist(DtoBusiness b)
            {

                listBusiness = myBllBusiness.GetAllBusinessFromBll();
                foreach (DtoBusiness item in listBusiness)
                {
                    if (item.businessID == b.businessID)
                       return item;
               }
               return null;
            }*/
        [HttpPost]
        public DtoTimeline UpdateTimeLine(DtoTimeline MyNewTimeLine)
        {
            MyNewTimeLine.exitTime = DateTime.Today;

            List<DtoTimeline> list = GetTimeLinebyDateAndEnteranceTime(MyNewTimeLine.businessID.ToString(), MyNewTimeLine.entranceDate.ToString(), MyNewTimeLine.entranceTime.ToString()).Where(e => e.customerID == MyNewTimeLine.customerID).ToList(); ;
            foreach (var item in list)
            {
                if (item.exitTime == null)
                {
                    return myBllTimeLine.updateTimeLineToBLL(item);

                }


            }
            return null;

        }
        [HttpPost]
        public DtoTimeline AddTimeLine(DtoTimeline MyNewTimeLine)
        {
            MyNewTimeLine.entranceDate = DateTime.Today;
            MyNewTimeLine.entranceTime = DateTime.Today;

            myBllTimeLine.AddTimeLineToBLL(MyNewTimeLine);
            return MyNewTimeLine;
        }
        [HttpGet]
        public List<DtoTimeline> GetTimeLinebyDate(string businessIdS)
        {
            DateTime d = DateTime.Today;

            //כל האנשים שלא יצאו
            return myBllTimeLine.GetAllBllTimeFromBll().Where(e => e.entranceDate == d && e.businessID == Convert.ToInt32(businessIdS)).ToList();
        }
        [HttpGet]
        public List<DtoTimeline> GetTimeLinebyDateAndEnteranceTime(string businessID, string dateS, string enteranceTimeS)
        {
            return myBllTimeLine.GetAllBllTimeFromBll().Where(e => e.entranceDate == Convert.ToDateTime(dateS) && (e.businessID == Convert.ToInt32(businessID)) && e.entranceTime >= Convert.ToDateTime(enteranceTimeS)).ToList();
        }

        [HttpGet]
        public List<DtoTimeline> GetTimeLinebyDatee(DateTime dateS, string businessID)
        {

            //כל האנשים שלא יצאו
            return myBllTimeLine.GetAllBllTimeFromBll().Where(e => e.entranceDate == dateS && e.businessID == Convert.ToInt32(businessID)).ToList();
        }
        [HttpGet]
        public List<DtoTimeline> GetTimeLinebyHouers(string businessID, string dateS, string entranceTimeS, string exitTimeS)
        {


            //רשימת האנשים שנכנסו היום
            listTimeLines = GetTimeLinebyDatee(Convert.ToDateTime(dateS), businessID);

            return listTimeLines.Where(e => e.entranceTime >= Convert.ToDateTime(entranceTimeS) && e.exitTime <= Convert.ToDateTime(exitTimeS)).ToList();
        }
         [HttpGet]
        public DateTime GetDate()
        {
            DateTime d = DateTime.Today;
            return d;
        }
    }
}