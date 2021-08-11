using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECTXDTO;

namespace PROJECTXDAL
{
    public class DeliveryModel_DAL
    {
		DemoEntities connect;

		public DeliveryModel_DAL()
		{

			connect = new DemoEntities();
		}
		public List<DeliveryModel_DTO> GetAllModels()
		{
			List<DeliveryModel_DTO> lstModels = new List<DeliveryModel_DTO>();
			try
			{
				var listOfModelsFromDb = connect.DeliveryModels.ToList();
				foreach (var item in listOfModelsFromDb)
				{
					lstModels.Add(
					new DeliveryModel_DTO()
					{
						ModelId=item.ModelId,
						ModelName=item.ModelName

					});
				}
				return lstModels;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
