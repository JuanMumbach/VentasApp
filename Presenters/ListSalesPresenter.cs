using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Views.Sale;

namespace VentasApp.Presenters
{
    public class ListSalesPresenter
    {
        private IListSalesView view;
        private ISaleRepository saleRepository;
        private BindingSource salesBindingSource;

        public ListSalesPresenter(IListSalesView listSalesView, ISaleRepository _saleRepository)
        {
            this.view = listSalesView;
            this.saleRepository = _saleRepository;
            this.salesBindingSource = new BindingSource();
            this.view.SaleListBindingSource = salesBindingSource;

            this.view.LoadAllSalesEvent += LoadAllSales;
            this.view.RestoreSaleEvent += OnRestoreSale;
            this.view.CancelSaleEvent += OnCancelSale;
            this.view.ViewSaleDetailEvent += OnViewSaleDetail;

            // Cargar la lista al iniciar
            LoadAllSales(this, EventArgs.Empty);
        }

        private void LoadAllSales(object? sender, EventArgs e)
        {
            IEnumerable<SaleModel> saleList = saleRepository.GetAllSales();
            salesBindingSource.DataSource = saleList;
        }

        private void OnViewSaleDetail(object? sender, EventArgs e)
        {
            int? saleId = view.GetSelectedSaleId();

            if (saleId != null)
            {
                try
                {
                    SaleView saleView = new SaleView();
                    saleView.SaleId = (int)saleId;

                    // 2. Crear un SalePresenter en modo SOLO LECTURA
                    new SalePresenter(
                        saleView,
                        new SaleRepository(),
                        new SaleItemRepository(),
                        new CustomerRepository(),
                        isReadOnly: true
                    );

                    // 3. Mostrar la vista de detalle
                    saleView.ShowDialog();

                    LoadAllSales(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    view.ShowMessage($"Error al cargar el detalle de la venta: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
            else
            {
                view.ShowMessage("Debes seleccionar una venta para ver el detalle.", "Advertencia", MessageBoxIcon.Warning);
            }
        }
        private void OnRestoreSale(object? sender, EventArgs e)
        {
            int? saleId = view.GetSelectedSaleId();
            if (saleId != null)
            {
                try
                {
                    saleRepository.RestoreSale((int)saleId);
                    view.ShowMessage($"Venta #{saleId} restaurada correctamente.", "Éxito", MessageBoxIcon.Information);
                    LoadAllSales(this, EventArgs.Empty); // Recargar la lista
                }
                catch (Exception ex)
                {
                    view.ShowMessage($"Error al restaurar la venta: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
            else
            {
                view.ShowMessage("Debes seleccionar una venta para restaurar.", "Advertencia", MessageBoxIcon.Warning);
            }
        }

        private void OnCancelSale(object? sender, EventArgs e)
        {
            int? saleId = view.GetSelectedSaleId();
            if (saleId != null)
            {
                DialogResult dialogResult = MessageBox.Show($"¿Estás seguro de que deseas cancelar la venta #{saleId}?",
                                                            "Confirmar Cancelación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        saleRepository.CancelSale((int)saleId);
                        view.ShowMessage($"Venta #{saleId} cancelada correctamente.", "Éxito", MessageBoxIcon.Information);
                        LoadAllSales(this, EventArgs.Empty); // Recargar la lista
                    }
                    catch (Exception ex)
                    {
                        view.ShowMessage($"Error al cancelar la venta: {ex.Message}", "Error", MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                view.ShowMessage("Debes seleccionar una venta para cancelar.", "Advertencia", MessageBoxIcon.Warning);
            }
        }
    }
}