using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL
{
    public class DalBusinessOwner
    {
        public List<BusinessOwner> GetAllBusinessOwnersFromDal()
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                List<BusinessOwner> bussinessOwnerList = db.BusinessOwners.ToList();
                return bussinessOwnerList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public BusinessOwner addBusinessOwnerToSQL(BusinessOwner businessOwner)
        {
            try
            {
               PurpleBadgeEntities db = new PurpleBadgeEntities();
                
                    db.BusinessOwners.Add(businessOwner);
                    db.SaveChanges();
                    return businessOwner;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
