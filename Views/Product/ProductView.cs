using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasApp.Models;
using VentasApp.Views.Product;

namespace VentasApp.Views
{
    public partial class ProductView : Form, IProductView
    {
        IEnumerable<CategoryModel> categories;
        IEnumerable<SupplierModel> suppliers;

        public event EventHandler AddProductEvent;
        public event EventHandler CancelProductAddEvent;
        public event EventHandler ChangeProductImageEvent;
        public event EventHandler UpdateProductEvent;

        public ProductView()
        {
            InitializeComponent();
            LoadCategories();
            LoadSuppliers();
            SwitchEditModeButtons();
            SetupEventsHandler();
        }

        public ProductView(int productId)
        {
            ProductId = productId;
            InitializeComponent();
            LoadCategories();
            LoadSuppliers();
            SwitchEditModeButtons();
            SetupEventsHandler();
        }

        private void SwitchEditModeButtons()
        {
            if (ProductId == null)
            {
                UpdateProductButton.Enabled = false;
                DeleteProductButton.Enabled = false;
            }
            else
            {
                UpdateProductButton.Enabled = true;
                DeleteProductButton.Enabled = true;
            }
        }

        private void SetupEventsHandler()
        {
            AddProductButton.Click += delegate { AddProductEvent?.Invoke(this, EventArgs.Empty); };
            CancelAddButton.Click += delegate { CancelProductAddEvent?.Invoke(this, EventArgs.Empty); };
            ChangeImageButton.Click += delegate { ChangeProductImageEvent?.Invoke(this, EventArgs.Empty); };
            UpdateProductButton.Click += delegate { UpdateProductEvent?.Invoke(this, EventArgs.Empty); };
        }

        public string ProductName
        {
            get { return NameTextbox.Text; }
            set { NameTextbox.Text = value.ToString(); }
        }

        public string ProductDescription
        {
            get { return DescriptionTextbox.Text; }
            set { DescriptionTextbox.Text = value.ToString(); }
        }
        public Decimal Price
        {
            get { return Decimal.Parse(PriceTextbox.Text); }
            set { PriceTextbox.Text = value.ToString(); }
        }
        public int Stock
        {
            get { return int.Parse(StockTextbox.Text); }
            set { StockTextbox.Text = value.ToString(); }
        }

        public int CategoryId
        {
            get
            {
                if (CategoryCombo.SelectedValue != null)
                {
                    return (int)CategoryCombo.SelectedValue;
                }
                return 0;
            }
            set
            {
                CategoryCombo.SelectedValue = value;
            }
        }

        public int? SupplierId
        {
            get
            {
                return (int?)SupplierCombo.SelectedValue;
            }
            set
            {
                if (value.HasValue)
                {
                    SupplierCombo.SelectedValue = value.Value;
                }
                else
                {
                    SupplierCombo.SelectedValue = null;
                }
            }
        }

        public int? ProductId { get; set; }

        public string? ImagePath { get; set; }
        public bool SecureImagePath { get; set; }

        public bool NotCloseAtUpdate
        {
            get { return CloseAtUpdateCheckbox.Checked; }
            set { CloseAtUpdateCheckbox.Checked = value; }
        }

        private void LoadCategories()
        {
            using (var dbcontext = new VentasDBContext())
            {
                categories = dbcontext.Categories.ToList();
                CategoryCombo.DataSource = categories;
                CategoryCombo.DisplayMember = "CategoryName";   //el string lleva el nombre de la propiedad de modelo
                CategoryCombo.ValueMember = "CategoryId";       //el string lleva el nombre de la propiedad de modelo
            }
        }

        private void LoadSuppliers()

        {
            using (var dbcontext = new VentasDBContext())
            {
                suppliers = dbcontext.Suppliers.ToList();
                var supplierList = new List<SupplierModel>(suppliers);
                supplierList.Insert(0, new SupplierModel { SupplierId = null, SupplierName = "--Sin definir--" });

                SupplierCombo.DataSource = supplierList;
                SupplierCombo.DisplayMember = "SupplierName";   //el string lleva el nombre de la propiedad de modelo
                SupplierCombo.ValueMember = "SupplierId";       //el string lleva el nombre de la propiedad de modelo
            }
        }

        public void UpdateViewProductImage()
        {

            if (SecureImagePath)
            {
                string fullImagePath = AppDomain.CurrentDomain.BaseDirectory + ImagePath;

                if (File.Exists(fullImagePath))
                {
                    ProductImageBox.Image = Image.FromFile(fullImagePath);
                }
            }
            else
            {
                if (ImagePath != null)
                {
                    ProductImageBox.Image = Image.FromFile(ImagePath);
                }
                else
                {
                    ProductImageBox.Image = null;
                }
            }
        }
        public void CloseView()
        {
            this.Close();
        }

        public void ShowDialogView()
        {
            this.ShowDialog();
        }
    }
}
