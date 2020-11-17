using Sample.Common.Models;
using Sample.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Repositories
{
    public class MedicineOrderRepository : BaseRepository<Order>, IMedicineOrderRepository
    {
        public MedicineOrderRepository(AppDBContext context): base(context) {}

        public async Task<bool> DeleteMedicineOrder(int medicineId)
        {
            Order entry = await base.GetByIdAsync(medicineId);
            try
            {
                if (entry != null)
                {
                    await base.Delete(entry);
                }
                return true;
            }
            catch (Exception ex)
            {
                // should be logged to insights
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Order>> GetAll()
        {
            return await base.GetAllAsync();
        }

        public async Task<Order> GetById(int medicineOrderId)
        {
            return await base.GetByIdAsync(medicineOrderId);
        }

        public async Task<Order> InsertMedicineOrder(Order medicineOrder)
        {
            await base.AddAsync(medicineOrder);
            return medicineOrder;
        }

        public async Task<Order> UpdateMedicineOrder(int medicineOrderId, Order medicineOrder)
        {
            Order medEntry = await base.GetByIdAsync(medicineOrderId);

            try
            {
                if (medEntry != null)
                {
                    await base.UpdateAsync(medicineOrder);
                }
                return medicineOrder;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
