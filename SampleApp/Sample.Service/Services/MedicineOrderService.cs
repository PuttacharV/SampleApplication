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
    public class MedicineOrderService : IMedicineOrderService
    {
        public readonly IMedicineOrderRepository _medicineOrderRepo;
        public MedicineOrderService(IMedicineOrderRepository medicineOrderRepo) 
        {
            _medicineOrderRepo = medicineOrderRepo;
        }

        public async Task<bool> DeleteMedicineOrder(int medicineOrderId)
        {
            return await _medicineOrderRepo.DeleteMedicineOrder(medicineOrderId);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _medicineOrderRepo.GetAll();
        }

        public async Task<Order> GetById(int medicineOrderId)
        {
            return await _medicineOrderRepo.GetById(medicineOrderId);
        }

        public async Task<Order> InsertMedicineOrder(Order medicineOrder)
        {
            return await _medicineOrderRepo.InsertMedicineOrder(medicineOrder);
        }

        public async Task<Order> UpdateMedicineOrder(int medicineOrderId, Order medicineOrder)
        {
            return await _medicineOrderRepo.UpdateMedicineOrder(medicineOrderId, medicineOrder);
        }
    }
}
