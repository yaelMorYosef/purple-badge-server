using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL;
using DTO;

namespace Converters
{
    public static class Converters
    {

        public static DtoBusiness ConvertBusinessToDTO(Business buss)
        {
            DtoBusiness business = new DtoBusiness()
            {
                businessAddress = buss.businessAddress,
                businessCity = buss.businessCity,
                businessID = buss.businessID,
                businessName = buss.businessName,
                businessOwnerID = buss.businessOwnerID,
                businessPhoneNo = buss.businessPhoneNo,
                businessSpace = Convert.ToBoolean(buss.businessSpace),
                noOfRegisters = Convert.ToInt32(buss.noOfRegisters)
            };


            return business;
        }
        public static Business ConvertBusinessToDAL(DtoBusiness buss)
        {
            Business business = new Business()
            {
                businessAddress = buss.businessAddress,
                businessCity = buss.businessCity,
                businessID = buss.businessID,
                businessName = buss.businessName,
                businessOwnerID = buss.businessOwnerID,
                businessPhoneNo = buss.businessPhoneNo,
                businessSpace = buss.businessSpace,
                noOfRegisters = buss.noOfRegisters

            };

            return business;

        }
        public static DtoBusinessUsers ConvertBusinessUserToDTO(BusinessUser businessU)
        {
            DtoBusinessUsers businessUser = new DtoBusinessUsers()
            {
                userName = businessU.userName,
                userPassword = businessU.userPassword
            };


            return businessUser;
        }
        public static BusinessUser ConvertBusinessUserToDAL(DtoBusinessUsers businessU)
        {
            BusinessUser businessUser = new BusinessUser()
            {
                userPassword = businessU.userPassword,

                userName = businessU.userName

            };

            return businessUser;

        }

        public static DTOCustomer ConvertCustomerToDTO(Customer cus)
        {
            DTOCustomer customer = new DTOCustomer()
            {
                customerID = cus.customerID,
                customerPhoneNo = cus.customerPhoneNo
            };


            return customer;
        }
        public static Customer ConvertCustomerToDAL(DTOCustomer cus)
        {
            Customer customer = new Customer()
            {
                customerPhoneNo = cus.customerPhoneNo,
                customerID = cus.customerID

            };

            return customer;

        }


        public static DtoBusinessOwner ConvertBusinessOwnerToDTO(BusinessOwner businessO)
        {
            DtoBusinessOwner businessOwner = new DtoBusinessOwner()
            {

                ownerID = businessO.ownerID,
                ownerName = businessO.ownerName,
                ownerPhoneNo = businessO.ownerPhoneNo

            };


            return businessOwner;
        }
        public static BusinessOwner ConvertBussinessOwnerToDAL(DtoBusinessOwner businessO)
        {
            BusinessOwner businessOwner = new BusinessOwner()
            {
                ownerPhoneNo = businessO.ownerPhoneNo,
                ownerName = businessO.ownerName,
                ownerID = businessO.ownerID,


            };

            return businessOwner;

        }

        public static DtoTimeline ConvertTimeLineToDTO(Timeline timeL)
        {
            DtoTimeline timeLine = new DtoTimeline()
            {
                businessID = timeL.businessID,
                customerID = timeL.customerID,
                entranceDate = timeL.entranceDate,
                entranceTime = timeL.entranceTime,
                exitTime = Convert.ToDateTime(timeL.exitTime)


            };


            return timeLine;
        }
        public static Timeline ConvertTimeLineDAL(DtoTimeline timeL)
        {
            Timeline timeLine = new Timeline()
            {
                businessID = timeL.businessID,
                customerID = timeL.customerID,
                entranceDate = timeL.entranceDate,
                entranceTime = timeL.entranceTime,
                exitTime = timeL.exitTime

            };

            return timeLine;

        }



    }
}