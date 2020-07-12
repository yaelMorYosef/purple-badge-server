using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL;
using DTO;

namespace _2_BLL
{
    public class BllCustomer
    {

        public List<DTOCustomer> GetAllCustomersFromBll()
        {
            DalCustomer dalCus = new DalCustomer();
            List<DTOCustomer> dtoCustomers = new List<DTOCustomer>();
            List<Customer> c = dalCus.GetAllCustomersFromDal();
            foreach (Customer currentCus in c)
            {
                dtoCustomers.Add(Converters.Converters.ConvertCustomerToDTO(currentCus));
            }
            return dtoCustomers;
        }

        public DTOCustomer AddCustomerToBLL(DTOCustomer c)
        {
            DalCustomer dc = new DalCustomer();
            return Converters.Converters.ConvertCustomerToDTO
                (dc.addCusstomerToSQL(Converters.Converters.ConvertCustomerToDAL(c)));
        }
    }
}
