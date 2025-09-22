using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Repositories;
using VentasApp.Views.Sale;

namespace VentasApp.Presenters
{
    public class SalePresenter
    {
        private ISaleView view;
        private ISaleRepository saleRepository;
        private ISaleItemRepository itemRepository;

        public SalePresenter(ISaleView saleView, ISaleRepository _saleRepository,ISaleItemRepository _itemRepository)
        {
            view = saleView;
            saleRepository = _saleRepository;
            itemRepository = _itemRepository;

        }
    }
}
