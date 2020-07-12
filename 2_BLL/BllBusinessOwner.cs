using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL;
using DTO;

namespace _2_BLL
{
    public class BllBusinessOwner
    {
        public List<DtoBusinessOwner> GetAllBusinessOwnerFromBll()
        {
            DalBusinessOwner bod = new DalBusinessOwner();

            List<DtoBusinessOwner> dtoBusinessOwner = new List<DtoBusinessOwner>();
            List<BusinessOwner> bo = bod.GetAllBusinessOwnersFromDal();
            foreach (BusinessOwner currentBussinesOwner in bo)
            {
                dtoBusinessOwner.Add(Converters.Converters.ConvertBusinessOwnerToDTO(currentBussinesOwner));
            }
            return dtoBusinessOwner;
        }

        public DtoBusinessOwner AddBusinessOwnerBLL(DtoBusinessOwner uu)
        {
            DalBusinessOwner dbo = new DalBusinessOwner();
            return Converters.Converters.ConvertBusinessOwnerToDTO
                 (dbo.addBusinessOwnerToSQL(Converters.Converters.ConvertBussinessOwnerToDAL(uu)));
        }




    }
}
