using System;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
using _2_BLL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using System.Threading.Tasks;




namespace YYPB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BusinessController : ApiController
    {



        private BllBusiness myBllBusiness = new BllBusiness();
        private List<DtoBusiness> listBusiness;


        /*     [HttpGet]
             public List<DtoBusiness> GetBusinessListById(int businessId)
             {

                 listBusiness = myBllBusiness.GetAllBusinessFromBll();
                 foreach (DtoBusiness item in listBusiness)
                 {
                     if (item.businessID == businessId)
                         listBusiness.Add(item);
                 }
                 return listBusiness;
             }*/
        [HttpGet]
        public List<DtoBusiness> GetAllBusiness()
        {
            List<DtoBusiness> buss =
                 myBllBusiness.GetAllBusinessFromBll();

            return buss;
        }
        //פונקציה המחזירה את רשימת העסקים של מנהל
        [HttpGet]
        public List<DtoBusiness> GetBusinessByOwnerId(string userName)
        {

            return myBllBusiness.GetAllBusinessFromBll().Where(e => e.businessOwnerID == userName).ToList();
        }
        [HttpGet]
        public int GetMaxIDBusiness()
        {
            if (GetAllBusiness() != null)
                return GetAllBusiness().Max(e => e.businessID) + 1;
            else
                return 1000;

        }
        [HttpGet]
        public DtoBusiness GetIfBusinessExist(string businessID)
        {

            listBusiness = myBllBusiness.GetAllBusinessFromBll();
            foreach (DtoBusiness item in listBusiness)
            {
                if (item.businessID == Convert.ToInt32(businessID))
                    return item;
            }
            return null;
        }

        [HttpGet]
        public DtoBusiness GetBusinessByBussinessID(int businessId)
        {

            listBusiness = myBllBusiness.GetAllBusinessFromBll();
            foreach (DtoBusiness item in listBusiness)
            {
                if (item.businessID == businessId)
                    return item;
            }
            return null;
        }
        [HttpPost]
        public DtoBusiness AddBusiness(DtoBusiness myyy)
        {

            if (GetIfBusinessExist(Convert.ToString(myyy.businessID)) == null)
            {
                myBllBusiness.AddBusinessToBLL(myyy);
                return myyy;
            }
            else
            {
                return null;
            }

        }
        [HttpGet]
        public string GetBusinessCoder(string urlBusiness)
        {
            MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = myBllBusiness.GetBusinessCoder(urlBusiness);
            Bitmap bmp = encoder.Encode(urlBusiness);
            //return bmp;
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
             //ms.ToArray();
            byte[] arr = ms.ToArray();
            string base64String = Convert.ToBase64String(arr);
            return base64String;
            





        }

    }
}

