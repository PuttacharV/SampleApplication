using Sample.Common.Models;
using Sample.DAL.IRepositories;
using Sample.DAL.Repositories;
using Sample.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.Services
{
    public class MedicineService : IMedicineService
    {
        public readonly IMedicineRepository _medicineRepo;
        public MedicineService(IMedicineRepository medicineRepo) 
        {
            _medicineRepo = medicineRepo;
        }

        public async Task<bool> DeleteMedicine(int medicineId)
        {
            return await _medicineRepo.DeleteMedicine(medicineId);
        }

        public async Task<List<Medicine>> GetAll()
        {
            return await _medicineRepo.GetAll();
        }

        public async Task<Medicine> GetById(int medicineId)
        {
            return await _medicineRepo.GetById(medicineId);
        }

        public async Task<Medicine> InsertMedicine(Medicine medicine)
        {
            return await _medicineRepo.InsertMedicine(medicine);
        }

        public async Task<Medicine> UpdateMedicinet(int medicineId, Medicine medicine)
        {
            return await _medicineRepo.UpdateMedicine(medicineId, medicine);
        }
    }
}
