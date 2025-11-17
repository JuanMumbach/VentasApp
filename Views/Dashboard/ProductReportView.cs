using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VentasApp.Models; // Necesario para referenciar CategoryModel y SupplierModel

namespace VentasApp.Views.Dashboard
{
    public interface IProductReportView : IBaseForm
    {
        event EventHandler CloseButtonClickEvent;
        event EventHandler ExportReportEvent;

        // Evento unificado para cuando cambia cualquiera de los filtros
        event EventHandler FilterChangedEvent;

        void ChangePeriodLabel(DateOnly startPeriod, DateOnly endPeriod);
        void DataGridBindSource(object source);

        // Métodos para llenar los combos
        void SetCategoriesDataSource(List<CategoryModel> categories);
        void SetSuppliersDataSource(List<SupplierModel> suppliers);

        // Propiedades para obtener lo seleccionado (0 si es "Todos")
        int SelectedCategoryId { get; }
        int SelectedSupplierId { get; }
    }

    public partial class ProductsReportView : BaseForm, IProductReportView
    {
        public event EventHandler CloseButtonClickEvent;
        public event EventHandler ExportReportEvent;
        public event EventHandler FilterChangedEvent;

        public ProductsReportView()
        {
            InitializeComponent();

            CloseButton.Click += (s, e) =>
            {
                CloseButtonClickEvent?.Invoke(s, e);
                this.Close();
            };

            ExportReportButton.Click += (s, e) =>
            {
                ExportReportEvent?.Invoke(s, e);           
            };

            CategoryFilterCombobox.SelectionChangeCommitted += (s, e) => FilterChangedEvent?.Invoke(s, e);
            SupplierFilterCombobox.SelectionChangeCommitted += (s, e) => FilterChangedEvent?.Invoke(s, e);
        }

        public void ChangePeriodLabel(DateOnly startPeriod, DateOnly endPeriod)
        {
            PeriodLabel.Text = $"Periodo: {startPeriod:dd/MM/yyyy} - {endPeriod:dd/MM/yyyy}";
        }

        public void DataGridBindSource(object source)
        {
            dataGridView1.DataSource = source;
        }

        public void SetCategoriesDataSource(List<CategoryModel> categories)
        {
            CategoryFilterCombobox.DataSource = categories;
            CategoryFilterCombobox.DisplayMember = "CategoryName";
            CategoryFilterCombobox.ValueMember = "CategoryId";
        }

        public void SetSuppliersDataSource(List<SupplierModel> suppliers)
        {
            SupplierFilterCombobox.DataSource = suppliers;
            SupplierFilterCombobox.DisplayMember = "SupplierName";
            SupplierFilterCombobox.ValueMember = "SupplierId";
        }

        public int SelectedCategoryId
        {
            get
            {
                if (CategoryFilterCombobox.SelectedValue != null && int.TryParse(CategoryFilterCombobox.SelectedValue.ToString(), out int id))
                {
                    return id;
                }
                return 0;
            }
        }

        public int SelectedSupplierId
        {
            get
            {
                if (SupplierFilterCombobox.SelectedValue != null && int.TryParse(SupplierFilterCombobox.SelectedValue.ToString(), out int id))
                {
                    return id;
                }
                return 0;
            }
        }
    }
}