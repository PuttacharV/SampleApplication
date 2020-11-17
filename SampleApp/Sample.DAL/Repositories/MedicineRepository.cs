using Sample.Common.Models;
using Sample.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Repositories
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(AppDBContext context): base(context) {}

        public async Task<bool> DeleteMedicine(int medicineId)
        {
            Medicine medEntry = await base.GetByIdAsync(medicineId);
            try
            {
                if (medEntry != null)
                {
                    await base.Delete(medEntry);
                }
                return true;
            }
            catch(Exception ex)
            {
                // should be logged to insights
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public async Task<List<Medicine>> GetAll()
        {
            return await base.GetAllAsync();
        }

        public async Task<Medicine> GetById(int medicineId)
        {
            return await base.GetByIdAsync(medicineId);
        }

        public async Task<Medicine> InsertMedicine(Medicine medicine)
        {
            await base.AddAsync(medicine);
            return medicine;
        }

        public async Task<Medicine> UpdateMedicine(int medicineId, Medicine medicine)
        {
            Medicine medEntry = await base.GetByIdAsync(medicineId);

            try
            {
                if (medEntry != null)
                {
                    await base.UpdateAsync(medicine);
                }
                return medicine;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
