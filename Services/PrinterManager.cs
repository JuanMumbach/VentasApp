using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;

namespace VentasApp.Services
{
    /// <summary>
    /// Manages printing operations for sales receipts.
    /// Provides formatted invoice printing functionality.
    /// </summary>
    public class PrinterManager : IDisposable
    {
        private PrintDocument printDocument;
        private readonly ILogger logger;
        private bool disposed = false;

        public PrinterManager(ILogger? logger = null)
        {
            printDocument = new PrintDocument();
            printDocument.PrinterSettings = new PrinterSettings();
            this.logger = logger ?? new FileLogger();
        }

        /// <summary>
        /// Prints a sales receipt for the given sale.
        /// </summary>
        public void PrintSaleReceipt(SaleModel sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale));
            }

            try
            {
                logger.LogInformation($"Printing receipt for sale ID: {sale.Id}");

                printDocument.PrintPage += (sender, e) => PrintSalePage(sender, e, sale);

                printDocument.Print();

                logger.LogInformation($"Receipt printed successfully for sale ID: {sale.Id}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error printing receipt for sale ID: {sale.Id}", ex);
                throw;
            }
            finally
            {
                printDocument.PrintPage -= (sender, e) => PrintSalePage(sender, e, sale);
            }
        }

        private void PrintSalePage(object sender, PrintPageEventArgs e, SaleModel sale)
        {
            if (e?.Graphics == null)
            {
                logger.LogError("Graphics object is null in PrintSalePage");
                return;
            }

            const int margin = 40;
            int width = e.PageBounds.Width - margin * 2;
            const int height = 30;
            int y = margin;
            int x = margin;

            const float prodIdColWeight = .8f;
            const float prodNameColWeight = 3;
            const float qtyColWeight = 1.2f;
            const float priceColWeight = 1.5f;
            const float totalColWeight = 1.5f;
            const float totalWeight = prodIdColWeight + prodNameColWeight + qtyColWeight + priceColWeight + totalColWeight;

            // Calculate text height for vertical centering
            Font font = new Font("Arial", 14);
            int textHeight = (int)font.GetHeight(e.Graphics);
            int textYoffset = (height - textHeight) / 2;

            // Draw enterprise info
            e.Graphics.DrawString("Razon social: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("Domicilio: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("CUIT: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("IVA:", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("Inicio Actividades: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;

            // Draw receipt info
            y = margin;
            e.Graphics.DrawString("Factura A/B/C ", font, Brushes.Black, new RectangleF(x + width / 2, y, width / 2, height));
            y += height;
            e.Graphics.DrawString($"Nº{sale.Id}", font, Brushes.Black, new RectangleF(x + width / 2, y, width / 2, height));
            y += height;
            e.Graphics.DrawString($"Fecha emision: {sale.CreatedAt:dd/MM/yyyy}", font, Brushes.Black, new RectangleF(x + width / 2, y, width / 2, height));
            y += height;

            // Draw split line
            e.Graphics.DrawLine(Pens.Black, x + width / 2, margin, x + width / 2, margin + height * 5);
            y = height * 6 + margin;

            // Draw customer info
            string customerName = sale.Customer?.FullName ?? "Consumidor Final";
            string customerAddress = sale.Customer?.Address ?? "";

            e.Graphics.DrawString("Cliente: " + customerName, font, Brushes.Black, new RectangleF(x, y, width, height));
            y += height;
            e.Graphics.DrawString("Domicilio: " + customerAddress, font, Brushes.Black, new RectangleF(x, y, width, height));
            y += height;

            // Draw header
            int colWidth = (int)(width / totalWeight * prodIdColWeight);
            int colX = x;
            e.Graphics.DrawString("Prod. Id", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            colX += colWidth;
            colWidth = (int)(width / totalWeight * prodNameColWeight);
            e.Graphics.DrawString("Producto", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            colX += colWidth;
            colWidth = (int)(width / totalWeight * qtyColWeight);
            e.Graphics.DrawString("Cantidad", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            colX += colWidth;
            colWidth = (int)(width / totalWeight * priceColWeight);
            e.Graphics.DrawString("Precio Unit.", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            colX += colWidth;
            colWidth = (int)(width / totalWeight * totalColWeight);
            e.Graphics.DrawString("Subtotal", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            y += height;

            // Draw items
            if (sale.SaleItems != null)
            {
                foreach (var item in sale.SaleItems)
                {
                    if (item?.Product == null) continue;

                    colWidth = (int)(width / totalWeight * prodIdColWeight);
                    colX = x;
                    e.Graphics.DrawString(item.ProductId.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                    colX += colWidth;
                    colWidth = (int)(width / totalWeight * prodNameColWeight);
                    e.Graphics.DrawString(item.Product.Name, font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                    colX += colWidth;
                    colWidth = (int)(width / totalWeight * qtyColWeight);
                    e.Graphics.DrawString(item.Amount.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                    colX += colWidth;
                    colWidth = (int)(width / totalWeight * priceColWeight);
                    e.Graphics.DrawString(item.Product.Price.ToString("C2"), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                    colX += colWidth;
                    colWidth = (int)(width / totalWeight * totalColWeight);
                    decimal subtotal = item.Amount * item.Price;
                    e.Graphics.DrawString(subtotal.ToString("C2"), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                    y += height;
                }
            }

            // Draw total
            y += height;
            colWidth = (int)(width / totalWeight * totalColWeight);
            e.Graphics.DrawString("Total", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));
            y += height;

            colWidth = (int)(width / totalWeight * totalColWeight);
            e.Graphics.DrawString(sale.TotalPrice.ToString("C2"), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            y += height;

            // Draw signature line
            int signWidth = 200;
            y = e.PageBounds.Height - margin - height;
            e.Graphics.DrawString("Recibí conforme", font, Brushes.Black, new RectangleF(width - margin - signWidth, y, signWidth, height));
            e.Graphics.DrawLine(Pens.Black, width - margin - signWidth, y, width - margin, y);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    printDocument?.Dispose();
                }
                disposed = true;
            }
        }
    }
}
