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
    public class BusinessUsersController : ApiController
    {
        private BllBusinessUsers myBllBusinessUser = new BllBusinessUsers();
        private List<DtoBusinessUsers> listBusinessUser;


        [HttpGet]
        [Route("api/BusinessUsers/GetBusinessUserById")]
        public DtoBusinessUsers GetBusinessUserById(string userName)
        {

            listBusinessUser = myBllBusinessUser.GetAllBusinessUsersFromBll();
            foreach (DtoBusinessUsers item in listBusinessUser)
            {
                if (item.userName == userName)
                    return item;
            }
            return null;
        }
      
        //אם סיסמא קיימת במערכת יחזיר אמת.. שיחפש סיסמא אחרת
        [HttpGet]
        public bool CheckIfPasswordExist(string password)
        {

            foreach (DtoBusinessUsers item in listBusinessUser)
            {
                if (item.userPassword == password)
                    return true;
            }
            return false;
        }

   

        [HttpPost]
        public DtoBusinessUsers AddBusinessUser(DtoBusinessUsers bu)
        {

            if (GetBusinessUserById(bu.userName) == null)
            {
                myBllBusinessUser.AddBusinessUserToBLL(bu);
                return bu;
            }
            else
            {
                return null;
            }

        }


    }
}