using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using _1_DAL;

namespace _2_BLL
{
    public class BllBusinessUsers
    {
        public List<DtoBusinessUsers> GetAllBusinessUsersFromBll()
        {
            DalBusinessUsers bud = new DalBusinessUsers();

            List<DtoBusinessUsers> dtoBusinessUser = new List<DtoBusinessUsers>();
            List<BusinessUser> bu = bud.GetAllBusinessUsersFromDal();
            foreach (BusinessUser currentBussinesUser in bu)
            {
                dtoBusinessUser.Add(Converters.Converters.ConvertBusinessUserToDTO(currentBussinesUser));
            }
            return dtoBusinessUser;
        }


        public DtoBusinessUsers AddBusinessUserToBLL(DtoBusinessUsers bu)
        {
            DalBusinessUsers dbu = new DalBusinessUsers();
            return Converters.Converters.ConvertBusinessUserToDTO
                (dbu.addBusinessuserToSQL(Converters.Converters.ConvertBusinessUserToDAL(bu)));
        }




    }
}
