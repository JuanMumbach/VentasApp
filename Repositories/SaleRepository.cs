using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models.DTOs;
using VentasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace VentasApp.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<SaleModel> GetAllSales();
        IEnumerable<SaleModel> GetCancelledSales(bool cancelState);
        SaleModel GetSaleById(int id);
        int AddSale(SaleModel sale);
        void UpdateSale(SaleModel sale);
        void CancelSale(int id);
        void RestoreSale(int id);
    }
    public class SaleRepository : ISaleRepository
    {
        public int AddSale(SaleModel sale)
        {
            using (var context = new VentasDBContext())
            {
                SaleModel newSale = new SaleModel
                {
                    CustomerId = sale.CustomerId,
                    CreatedAt = DateTime.Now,
                    SaleItems = sale.SaleItems,
                    TotalPrice = 0
                };
                
                foreach (var item in newSale.SaleItems)
                {
                    if (item.Product != null)
                    {
                        //sumar el precio del item al total de la venta
                        newSale.TotalPrice += item.Price * item.Amount;
                        
                        // Marcar la Categoria como "Unchanged"
                        // Esto resuelve el error "Duplicate entry for category.PRIMARY"
                        if (item.Product.Category != null)
                        {
                            
                            context.Entry(item.Product.Category).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        }

                        // Marcar el Proveedor (Supplier) como "Unchanged"
                        if (item.Product.Supplier != null)
                        {
                            context.Entry(item.Product.Supplier).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        }

                        // Marcar el Producto como "Unchanged"
                        // Esto es necesario para que EF no intente insertarlo de nuevo.
                        context.Entry(item.Product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    }
                }
                
                context.Sales.Add(sale);
                context.SaveChanges();
                return sale.Id;
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
                return context.Sales.Include(sale => sale.Customer).ToList();
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
                return context.Sales
                      .Include(s => s.Customer) 
                      .Include(s => s.SaleItems)
                          .ThenInclude(si => si.Product)
                              .ThenInclude(p => p.Category)
                      .FirstOrDefault(s => s.Id == id);
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
