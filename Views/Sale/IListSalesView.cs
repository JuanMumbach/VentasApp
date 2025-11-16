using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasApp.Models;

namespace VentasApp.Views.Sale
{
    public interface IListSalesView : IBaseForm
    {
        BindingSource SaleListBindingSource { set; }
        event EventHandler LoadAllSalesEvent;
        event EventHandler RestoreSaleEvent;

        event EventHandler CancelSaleEvent;
        event EventHandler ViewSaleDetailEvent;
        event EventHandler OnChangeSelectedSaleEvent;
        event EventHandler OnChangeDeliveryStateEvent;

        string DeliveryState { get; set; }
        int? GetSelectedSaleId();

        void ShowMessage(string message, string title, MessageBoxIcon icon);

        void SetViewOnlyMode();
        void SetDeliveryStateOptions(List<string> states);
    }
}