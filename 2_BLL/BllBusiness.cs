using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using _1_DAL;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

using System.Drawing;


namespace _2_BLL
{
  public  class BllBusiness
    {
        public List<DtoBusiness> GetAllBusinessFromBll()
        {
            DalBusiness dalBus = new DalBusiness();
            List<DtoBusiness> dtoBusiness = new List<DtoBusiness>();
            List<Business> b = dalBus.GetAllBusinessFromDal();
            foreach (Business currentBus in b)
            {
                dtoBusiness.Add(Converters.Converters.ConvertBusinessToDTO(currentBus));
            }
            return dtoBusiness;
        }

        public DtoBusiness AddBusinessToBLL(DtoBusiness b)
        {
            DalBusiness bb = new DalBusiness();
            return Converters.Converters.ConvertBusinessToDTO
                (bb.addBusinessToSQL(Converters.Converters.ConvertBusinessToDAL(b)));
        }

      public QRCodeEncoder GetBusinessCoder(string urlBusiness)
        {
            DalBusiness bb = new DalBusiness();
            return bb.GetBusinessCoder(urlBusiness);
        }
    }


}

