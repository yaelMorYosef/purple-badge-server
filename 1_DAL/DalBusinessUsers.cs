using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL
{
    public class DalBusinessUsers
    {

        public List<BusinessUser> GetAllBusinessUsersFromDal()
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                List<BusinessUser> BusinessUserList = db.BusinessUsers.ToList();
                return BusinessUserList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public BusinessUser addBusinessuserToSQL(BusinessUser businessUser)
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                
                    db.BusinessUsers.Add(businessUser);
                    db.SaveChanges();
                    return businessUser;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
