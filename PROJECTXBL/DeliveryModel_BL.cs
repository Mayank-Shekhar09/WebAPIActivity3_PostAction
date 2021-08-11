using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECTXDTO;
using PROJECTXDAL;

namespace PROJECTXBL
{
    public class DeliveryModel_BL
    {
        DeliveryModel_DAL modelDalObj;
        public DeliveryModel_BL()
        {
            modelDalObj = new DeliveryModel_DAL();
        }
        public List<DeliveryModel_DTO> GetAllModels()
        {
            try
            {
                var lstModels = modelDalObj.GetAllModels();
                return lstModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
