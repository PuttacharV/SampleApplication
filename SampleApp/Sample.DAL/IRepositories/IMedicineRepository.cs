using Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.IRepositories
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAll();
        Task<Medicine> GetById(int medicineId);
        Task<Medicine> InsertMedicine(Medicine medicine);
        Task<Medicine> UpdateMedicine(int medicineId, Medicine medicine);
        Task<bool> DeleteMedicine(int medicineId);
    }
}
