using Sample.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.IServices
{
    public interface IMedicineOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int medicineOrderId);
        Task<Order> InsertMedicineOrder(Order medicineOrder);
        Task<Order> UpdateMedicineOrder(int medicineOrderId, Order medicineOrder);
        Task<bool> DeleteMedicineOrder(int medicineOrderId);
    }
}
