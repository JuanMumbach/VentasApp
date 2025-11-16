using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Repositories;
using VentasApp.Services;
using VentasApp.Views.Sale;
using static VentasApp.Services.PermissionManager;

namespace VentasApp.Presenters
{
    public class ListSalesPresenter
    {
        private IListSalesView view;
        private ISaleRepository saleRepository;
        private BindingSource salesBindingSource;
        private bool showOnlyUserSales = false;
        private bool AccessGranted = false;

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
            this.view.OnChangeSelectedSaleEvent += ChangeSelectedDeliveryState;
            this.view.OnChangeDeliveryStateEvent += UpdateSaleDeliveryState;

            this.view.FormLoadEvent += CheckForPermission;

            // Cargar la lista al iniciar
            // Comentado para cargar lista despues de ejecutar el CheckForPermission
            //LoadAllSales(this, EventArgs.Empty);
        }

        private void UpdateSaleDeliveryState(object? sender, EventArgs e)
        {
            if (view.GetSelectedSaleId() == null) return;

            int selectedSaleId = (int)view.GetSelectedSaleId();
            SaleModel sale = saleRepository.GetSaleById(selectedSaleId);

            if (sale == null) return;

            if (sale.DeliveryState == this.view.DeliveryState) return;

            if (MessageBox.Show("¿Está seguro de que desea actualizar el estado de la entrega?\n" +
                        $"Estado actual: {sale.DeliveryState}\n" +
                        $"Nuevo estado: {this.view.DeliveryState}",
                        "Confirmar Actualización",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                ChangeSelectedDeliveryState(this, EventArgs.Empty);
                return; 
            }

            sale.DeliveryState = this.view.DeliveryState;
            saleRepository.UpdateSale(sale);
            LoadAllSales(this,EventArgs.Empty);
        }

        private void ChangeSelectedDeliveryState(object? sender, EventArgs e)
        {
            if (view.GetSelectedSaleId() == null) return;

            int selectedSaleId = (int)view.GetSelectedSaleId();
            SaleModel sale = saleRepository.GetSaleById(selectedSaleId);

            if (sale == null) return;

            this.view.DeliveryState = sale.DeliveryState;
        }

        

        private void CheckForPermission(object? sender, EventArgs e)
        {
            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesManage))
            {
                showOnlyUserSales = false;
                AccessGranted = true;
                LoadAllSales(this, EventArgs.Empty);
                LoadDeliveryStates();
                return;
            }

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesViewAll))
            {
                showOnlyUserSales = false;
                AccessGranted = true;
                view.SetViewOnlyMode();
                LoadAllSales(this, EventArgs.Empty);
                return;
            }

            

            if (HasPermission((Roles)SessionManager.CurrentUserRoleId, Permissions.SalesCreate))
            {
                showOnlyUserSales = true;
                AccessGranted = true;
                LoadAllSales(this, EventArgs.Empty);
                LoadDeliveryStates();
                return;
            }

            MessageBox.Show("No tienes permisos para ver esta sección.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            view.CloseView();

        }

        private void LoadAllSales(object? sender, EventArgs e)
        {

            if (!AccessGranted) return;

            IEnumerable<SaleModel> saleList = new List<SaleModel>();
            
            if (showOnlyUserSales)
            {
                saleList = saleRepository.GetAllSalesByUser(SessionManager.CurrentUserId);
            }
            else
            {
                saleList = saleRepository.GetAllSales();
            }
                

            var displayList = saleList.Select(item => new
            {
                Id = item.Id,
                Cliente = item.Customer != null ? $"{item.Customer.Firstname} {item.Customer.Lastname}" : "No registrado",
                Fecha = item.CreatedAt.ToString("g"),
                Actualizado = item.UpdatedAt.ToString("g"),
                Estado = item.CanceledAt != null ? $"Cancelado {((DateTime)item.CanceledAt).ToString("g")}" : "Activo",
                Entrega = item.DeliveryState,
                Total = item.TotalPrice.ToString("C2"),
            }).ToList();

            salesBindingSource.DataSource = displayList;
        }

        void LoadDeliveryStates()
        {
            var states = saleRepository.GetDeliveryStates();

            this.view.SetDeliveryStateOptions(states);
        }

        private void OnViewSaleDetail(object? sender, EventArgs e)
        {
            int? saleId = view.GetSelectedSaleId();


            if (saleId != null)
            {
                try
                {
                    SaleModel sale = saleRepository.GetSaleById((int)saleId);
                    SaleView saleView = new SaleView();                    

                    // 2. Crear un SalePresenter en modo SOLO LECTURA
                    new SalePresenter(
                        saleView,
                        new SaleRepository(),
                        new SaleItemRepository(),
                        new CustomerRepository(),
                        sale
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