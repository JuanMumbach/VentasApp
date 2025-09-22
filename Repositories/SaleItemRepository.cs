using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models.DTOs;
using VentasApp.Models;

namespace VentasApp.Repositories
{
    public interface ISaleItemRepository
    {
        SaleItemModel GetSaleItemById(int id);
        IEnumerable<SaleItemModel> GetAllItemsOfSale(int SaleId);

        void AddSaleItem(SaleItemModel saleItem);
        void UpdateSaleItem(SaleItemModel saleItem);
        void DeleteSaleItem(int id);     
    }
    public class SaleItemRepository : ISaleItemRepository
    {
        public void AddSaleItem(SaleItemModel saleItem)
        {
            using (var context = new VentasDBContext())
            {
                saleItem.CreatedAt = DateTime.Now;
                saleItem.UpdatedAt = DateTime.Now;
                context.SalesItems.Add(saleItem);
                context.SaveChanges();
            }
        }

        public void DeleteSaleItem(int id)
        {
            using (var context = new VentasDBContext())
            {
                SaleItemModel saleItem = GetSaleItemById(id);
                context.SalesItems.Remove(saleItem);
                context.SaveChanges();
            }
        }

        public IEnumerable<SaleItemModel> GetAllItemsOfSale(int SaleId)
        {
            using (var context = new VentasDBContext())
            {
                return context.SalesItems.Where(item => item.SaleId == SaleId).ToList();
            }
        }

        public SaleItemModel GetSaleItemById(int id)
        {
            using (var context = new VentasDBContext())
            {
                return context.SalesItems.Find(id);
            }
            
        }

        public void UpdateSaleItem(SaleItemModel saleItem)
        {
            using (var context = new VentasDBContext())
            {
                saleItem.UpdatedAt = DateTime.Now;
                context.SalesItems.Update(saleItem);
                context.SaveChanges();
            }
        }
    }
}
