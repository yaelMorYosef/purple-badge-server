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

    public class BusinessOwnerController : ApiController
    {
   
        private BllBusinessOwner myBllBusinessOwner = new BllBusinessOwner();
        private List<DtoBusinessOwner> listBusinessOwner;
   


        [HttpGet]
        public DtoBusinessOwner GetBusinessOwnerById(string ownerId)
        {

            listBusinessOwner = myBllBusinessOwner.GetAllBusinessOwnerFromBll();
            foreach (DtoBusinessOwner item in listBusinessOwner)
            {
                if (item.ownerID == ownerId)
                    return item;
            }
            return null;
        }
        [HttpGet]
        public List<DtoBusinessOwner> GetAllBusinessOwners()
        {
            List<DtoBusinessOwner> businessO =
                 myBllBusinessOwner.GetAllBusinessOwnerFromBll();

            return businessO;
        }
       
      

        [HttpPost]
        public DtoBusinessOwner AddBusinessOwner(DtoBusinessOwner bo)
        {

            if (GetBusinessOwnerById(bo.ownerID) == null)
            {
                myBllBusinessOwner.AddBusinessOwnerBLL(bo);
      
                return bo;
            }
            else
            {
                return null;
            }

        }
    }
}