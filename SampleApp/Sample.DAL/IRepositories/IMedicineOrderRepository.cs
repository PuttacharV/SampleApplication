using Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.IRepositories
{
    public interface IMedicineOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int medicineOrderId);
        Task<Order> InsertMedicineOrder(Order medicineOrder);
        Task<Order> UpdateMedicineOrder(int medicineId, Order medicine);
        Task<bool> DeleteMedicineOrder(int medicineId);
    }
}
