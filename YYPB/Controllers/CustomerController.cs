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
    public class CustomerController : ApiController
    {
        private BllCustomer myBllCustomers = new BllCustomer();
        private List<DTOCustomer> listCustomers;


        [HttpGet]
        public DTOCustomer GetCustomersById(string cusId)
        {

            listCustomers = myBllCustomers.GetAllCustomersFromBll();
            foreach (DTOCustomer item in listCustomers)
            {
                if (item.customerID == cusId)
                    return item;
            }
            return null;
        }
        [HttpGet]
        public List<DTOCustomer> GetAllCustoners()
        {
            List<DTOCustomer> cuss =
                 myBllCustomers.GetAllCustomersFromBll();

            return cuss;
        }
        //לקוח מצטרף למאגר פעם אחת כשנכנס לחנות ראשונה
        [HttpPost]
        public void AddCustomer(DTOCustomer MyNewCustomer)
        {

            if (GetCustomersById(MyNewCustomer.customerID) == null)
            {
                myBllCustomers.AddCustomerToBLL(MyNewCustomer);

            }
            //אם קיים במערכת -אין צורך להוסיפו!

        }


    }
}