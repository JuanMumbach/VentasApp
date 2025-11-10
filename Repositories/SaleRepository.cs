using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<SaleModel> GetAllSales();
        IEnumerable<SaleModel> GetAllSalesByUser(int UserId);
        IEnumerable<SaleModel> GetCancelledSales(bool cancelState);
        SaleModel GetSaleById(int id);
        int AddSale(SaleModel sale);
        void UpdateSale(SaleModel sale);
        void CancelSale(int id);
        void RestoreSale(int id);
        IEnumerable<SalesDataPoint> GetSalesGroupedByDate(DateTime start, DateTime end, int intervalDays);
    }
    public class SaleRepository : ISaleRepository
    {
        public int AddSale(SaleModel sale)
        {
            using (var context = new VentasDBContext())
            {
                decimal total = 0;
                foreach (var item in sale.SaleItems)
                {
                    item.Product = null;
                    if (item.Product != null)
                    {                     
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
                    total += item.Price * item.Amount;
                    
                }

                sale.TotalPrice = total;

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

        public IEnumerable<SaleModel> GetAllSalesByUser(int UserId)
        {
            using (var context = new VentasDBContext())
            {
                return context.Sales.Where(sale => sale.UserId == UserId)
                    .Include(sale => sale.Customer)
                    .ToList();
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

        public IEnumerable<SalesDataPoint> GetSalesGroupedByDate(DateTime start, DateTime end, int intervalDays)
        {
            if (intervalDays <= 0)
            {
                throw new ArgumentException("El intervalo de días debe ser mayor que cero.", nameof(intervalDays));
            }

            using (var context = new VentasDBContext())
            {
                // --- 1. Ejecutar la consulta en la DB hasta aquí ---
                // Se trae la lista de ventas del rango (la parte simple) a la memoria de la aplicación.
                var salesInRange = context.Sales
                    .Where(sale => sale.CreatedAt >= start && sale.CreatedAt <= end && sale.CanceledAt == null)
                    .ToList(); // <--- ¡AQUÍ ESTÁ LA CLAVE! El .ToList() ejecuta el SQL.

                // --- 2. Continuar con LINQ to Objects (en memoria) ---
                var query = salesInRange
                    // Ahora este GroupBy se ejecuta en la memoria de C#, donde la lambda compleja es válida.
                    .GroupBy(sale =>
                    {
                        // La lógica compleja que no se traduce a SQL
                        var daysDifference = (sale.CreatedAt.Date - start.Date).Days;
                        var groupIndex = daysDifference / intervalDays;
                        return start.Date.AddDays(groupIndex * intervalDays);
                    })
                    .Select(group => new SalesDataPoint
                    {
                        Date = group.Key,
                        TotalSales = group.Sum(sale => sale.TotalPrice),
                        SaleCount = group.Count()
                    })
                    .OrderBy(result => result.Date);

                return query.ToList();
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
