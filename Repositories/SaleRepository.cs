using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models.DTOs;
using VentasApp.Models;

namespace VentasApp.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<SaleModel> GetAllSales();
        IEnumerable<SaleModel> GetCancelledSales(bool cancelState);
        SaleModel GetSaleById(int id);
        void AddSale(SaleModel sale);
        void UpdateSale(SaleModel sale);
        void CancelSale(int id);
        void RestoreSale(int id);
    }
    public class SaleRepository : ISaleRepository
    {
        public void AddSale(SaleModel sale)
        {
            using (var context = new VentasDBContext())
            {
                context.Sales.Add(sale);
                context.SaveChanges();
            }
        }

        public void CancelSale(int id)
        {
            using (var context = new VentasDBContext())
            {
                SaleModel sale = GetSaleById(id);
                sale.CanceledAt = DateTime.Now;
                context.Sales.Update(sale);
                context.SaveChanges();
            }
        }

        public IEnumerable<SaleModel> GetAllSales()
        {
            using (var context = new VentasDBContext())
            {
                return context.Sales.ToList();
            }
        }

        public IEnumerable<SaleModel> GetCancelledSales(bool cancelState)
        {
            using (var context = new VentasDBContext())
            {
                return context.Sales.Where(p => p.CanceledAt.HasValue == cancelState).ToList();
            }
        }

        public SaleModel GetSaleById(int id)
        {
            using (var context = new VentasDBContext())
            {
                return context.Sales.Find(id);
            }
        }

        public void RestoreSale(int id)
        {
            using (var context = new VentasDBContext())
            {
                SaleModel sale = GetSaleById(id);
                sale.CanceledAt = null;
                context.Sales.Update(sale);
                context.SaveChanges();
            }
        }

        public void UpdateSale(SaleModel sale)
        {
            using (var context = new VentasDBContext())
            {
                context.Sales.Update(sale);
                context.SaveChanges();
            }
        }
    }
}
