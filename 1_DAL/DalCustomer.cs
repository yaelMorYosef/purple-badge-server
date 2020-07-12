using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL
{
    public class DalCustomer
    {


        public List<Customer> GetAllCustomersFromDal()
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                List<Customer> CustomersList = db.Customers.ToList();
                return CustomersList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Customer addCusstomerToSQL(Customer customer)
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return customer;
                }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
