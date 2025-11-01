using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Models;

namespace VentasApp.Services
{
    public class PrinterManager
    {
        PrintDocument printDocument;

        public PrinterManager()
        {
            printDocument = new PrintDocument();
            printDocument.PrinterSettings = new PrinterSettings();
            
        }
        public void PrintSaleReceipt(SaleModel sale)
        {
            printDocument.PrintPage += (sender, e) => PrintSalePage(sender, e, sale);
            try
            {
                printDocument.Print();
            }
            finally
            {
                               printDocument.PrintPage -= (sender, e) => PrintSalePage(sender, e, sale);
            }
        }

        private void PrintSalePage(object sender, PrintPageEventArgs e, SaleModel sale)
        {
            int margin = 40;
            int width = e.PageBounds.Width - margin*2;
            int height = 30;
            int y = margin;
            int x = margin;

            float prodIdColWeight = .8f;
            float prodNameColWeight = 3;
            float qtyColWeight = 1.2f;
            float priceColWeight = 1.5f;
            float totalColWeight = 1.5f;
            float totalWeight = prodIdColWeight + prodNameColWeight + qtyColWeight + priceColWeight + totalColWeight;

            //calculate text height for vertical centering
            Font font = new Font("Arial", 14);
            int textHeight = (int)font.GetHeight(e.Graphics);
            int textYoffset = (height - textHeight) / 2;

            //draw enterprise info
            e.Graphics.DrawString("Razon social: ", font, Brushes.Black, new RectangleF(x, y, width/2, height));
            y+= height;
            e.Graphics.DrawString("Domicilio: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("CUIT: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("IVA:", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;
            e.Graphics.DrawString("Inicio Actividades: ", font, Brushes.Black, new RectangleF(x, y, width / 2, height));
            y += height;

            //draw receipt info
            y = margin;
            e.Graphics.DrawString("Factura A/B/C ", font, Brushes.Black, new RectangleF(x + width / 2, y, width / 2, height));
            y += height;
            e.Graphics.DrawString($"Nº{sale.Id}", font, Brushes.Black, new RectangleF(x + width / 2, y, width / 2, height));
            y += height;
            e.Graphics.DrawString($"Fecha emision: {sale.CreatedAt.ToString("dd/MM/yyyy")}", font, Brushes.Black, new RectangleF(x + width / 2, y, width / 2, height));
            y += height;

            //draw split line
            e.Graphics.DrawLine(Pens.Black, x + width / 2, margin, x + width / 2, margin + height*5);
            y = height * 6 + margin;

            //draw customer info
            e.Graphics.DrawString("Cliente: " + (sale.Customer != null ? sale.Customer.FullName : ""), font, Brushes.Black, new RectangleF(x, y, width, height));
            y += height;

            e.Graphics.DrawString("Domicilio: " + (sale.Customer != null ? sale.Customer.Address : ""), font, Brushes.Black, new RectangleF(x, y, width, height));
            y += height;

            

            //draw header
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

            //draw items
            foreach (var item in sale.SaleItems)
            {
                colWidth = (int)(width/totalWeight*prodIdColWeight);
                colX = x;
                e.Graphics.DrawString(item.ProductId.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth,height));               
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                colX += colWidth;
                colWidth = (int)(width/totalWeight*prodNameColWeight);
                e.Graphics.DrawString(item.Product.Name, font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                colX += colWidth;
                colWidth = (int)(width / totalWeight * qtyColWeight);
                e.Graphics.DrawString(item.Amount.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                colX += colWidth;
                colWidth = (int)(width / totalWeight * priceColWeight);
                e.Graphics.DrawString(item.Product.Price.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                colX += colWidth;
                colWidth = (int)(width / totalWeight * totalColWeight);
                decimal subtotal = item.Amount * item.Price;
                e.Graphics.DrawString(subtotal.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

                y += height;
            }

            //draw total
            y += height;
            colWidth = (int)(width / totalWeight * totalColWeight);
            e.Graphics.DrawString("Total", font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));
            y += height;

            colWidth = (int)(width / totalWeight * totalColWeight);
            e.Graphics.DrawString(sale.TotalPrice.ToString(), font, Brushes.Black, new RectangleF(colX, y + textYoffset, colWidth, height));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(colX, y, colWidth, height));

            y += height;


            // draw signature line
            int signWidth = 200;
            y = e.PageBounds.Height - margin - height;
            e.Graphics.DrawString("Recibí conforme", font, Brushes.Black, new RectangleF(width-margin-signWidth, y, signWidth, height));
            e.Graphics.DrawLine(Pens.Black, width - margin - signWidth, y, width - margin, y);
        }
    }
}
