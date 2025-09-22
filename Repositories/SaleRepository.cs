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
        IEnumerable<SaleModel> GetCancelledProducts(bool cancelState);
        SaleModel GetSaleById(int id);
        void AddSale(SaleModel sale);
        void UpdateSale(int id);
        void DeleteSale(int id);
        void RestoreSale(int id);
    }
    public class SaleRepository : ISaleRepository
    {
        public void AddSale(SaleModel sale)
        {
            throw new NotImplementedException();
        }

        public void DeleteSale(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleModel> GetAllSales()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleModel> GetCancelledProducts(bool cancelState)
        {
            throw new NotImplementedException();
        }

        public SaleModel GetSaleById(int id)
        {
            throw new NotImplementedException();
        }

        public void RestoreSale(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSale(int id)
        {
            throw new NotImplementedException();
        }
    }
}
