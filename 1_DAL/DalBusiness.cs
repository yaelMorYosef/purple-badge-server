
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;




namespace _1_DAL
{
    public class DalBusiness
    {
        public List<Business> GetAllBusinessFromDal()
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
                List<Business> bussinessList = db.Businesses.ToList();
                return bussinessList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Business addBusinessToSQL(Business business)
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();

                db.Businesses.Add(business);
                db.SaveChanges();
                return business;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public QRCodeEncoder GetBusinessCoder(string urlBusiness)
        {
            try
            {
                PurpleBadgeEntities db = new PurpleBadgeEntities();
               // db.Filter=@"JPEG files|*.jpg;*.jpeg";
               MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder= new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                encoder.QRCodeScale=8;

                return encoder;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    

    }
}
