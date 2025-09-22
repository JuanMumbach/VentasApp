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
        IEnumerator<SaleItemModel> GetAllItemsOfSale(int SaleId);

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

        public IEnumerator<SaleItemModel> GetAllItemsOfSale(int SaleId)
        {
            throw new NotImplementedException();
        }

        public SaleItemModel GetSaleItemById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSaleItem(SaleItemModel saleItem)
        {
            throw new NotImplementedException();
        }
    }
}
