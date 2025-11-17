using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Services
{
    public class PdfService
    {
        public PdfService()
        {
   
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public void ExportarDatosTabla<T>(string titulo, string periodo, List<T> datos, string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));


                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text(titulo).Bold().FontSize(20).FontColor(Colors.Blue.Medium);
                            col.Item().Text(periodo).FontSize(12);
                        });

                    });

                    page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                    {

                        var propiedades = typeof(T).GetProperties();

                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var prop in propiedades)
                            {
                                columns.RelativeColumn();
                            }
                        });

                        table.Header(header =>
                        {
                            foreach (var prop in propiedades)
                            {
                                header.Cell().Element(EstiloCeldaHeader).Text(prop.Name);
                            }
                        });

                        foreach (var item in datos)
                        {
                            foreach (var prop in propiedades)
                            {
                                var valor = prop.GetValue(item)?.ToString() ?? "";
                                table.Cell().Element(EstiloCeldaDato).Text(valor);
                            }
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(rutaArchivo);
        }

        public void ExportarFactura(SaleModel venta, string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(2, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("VentasApp S.A.").Bold().FontSize(20);
                            col.Item().Text("Dirección de la empresa");
                            col.Item().Text("CUIT: 20-12345678-9");
                        });

                        row.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text($"Factura N° {venta.Id}").Bold().FontSize(16);
                            col.Item().Text($"Fecha: {venta.CreatedAt:dd/MM/yyyy}");
                            col.Item().Text(venta.DeliveryState ?? "Estado: Pendiente");
                        });
                    });

                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                    {

                        col.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten1).PaddingBottom(5).Row(row =>
                        {
                            var nombreCliente = venta.Customer != null ? venta.Customer.FullName : "Consumidor Final";
                            var direccion = venta.Customer != null ? venta.Customer.Address : "-";

                            row.RelativeItem().Text($"Cliente: {nombreCliente}");
                            row.RelativeItem().AlignRight().Text($"Domicilio: {direccion}");
                        });

                        col.Item().Height(10); 

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(50); // ID
                                columns.RelativeColumn();   // Producto
                                columns.ConstantColumn(50); // Cant
                                columns.ConstantColumn(80); // Precio
                                columns.ConstantColumn(80); // Total
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(EstiloCeldaHeader).Text("ID");
                                header.Cell().Element(EstiloCeldaHeader).Text("Producto");
                                header.Cell().Element(EstiloCeldaHeader).Text("Cant");
                                header.Cell().Element(EstiloCeldaHeader).AlignRight().Text("Precio Unit.");
                                header.Cell().Element(EstiloCeldaHeader).AlignRight().Text("Subtotal");
                            });

                            foreach (var item in venta.SaleItems)
                            {
                                table.Cell().Element(EstiloCeldaDato).Text(item.ProductId.ToString());
                                table.Cell().Element(EstiloCeldaDato).Text(item.Product.Name);
                                table.Cell().Element(EstiloCeldaDato).AlignCenter().Text(item.Amount.ToString());
                                table.Cell().Element(EstiloCeldaDato).AlignRight().Text($"${item.Price:N2}");
                                table.Cell().Element(EstiloCeldaDato).AlignRight().Text($"${(item.Price * item.Amount):N2}");
                            }
                        });

                        col.Item().AlignRight().PaddingTop(10).Text($"TOTAL: ${venta.TotalPrice:N2}").Bold().FontSize(14);
                    });

                    page.Footer().AlignCenter().Text("Gracias por su compra.");
                });
            })
            .GeneratePdf(rutaArchivo);
        }

        public void ExportFullDashboard(DashboardExportDTO datos, string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // --- CABECERA ---
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Resumen Ejecutivo").Bold().FontSize(22).FontColor(Colors.Blue.Darken2);
                            col.Item().Text($"Generado: {datos.FechaGeneracion:g}").FontSize(10).FontColor(Colors.Grey.Medium);
                            col.Item().Text(datos.Periodo).FontSize(12).SemiBold();
                        });
                    });

                    // --- CONTENIDO ---
                    page.Content().PaddingVertical(10).Column(col =>
                    {

                        col.Item().Row(row =>
                        {
                           
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Ingresos del Periodo").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"${datos.TotalIngresos:N2}").Bold().FontSize(20).FontColor(Colors.Green.Darken2);
                            });

                            row.ConstantItem(10);

                        
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Total Operaciones").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"{datos.TotalVentas}").Bold().FontSize(20).FontColor(Colors.Blue.Darken2);
                            });

                            
                            row.ConstantItem(10);
                            row.RelativeItem().Component(new PlaceholderKpi());
                        });

                        col.Item().Height(20);

                        // Gráfico Principal
                        col.Item().Text("Evolución de Ventas").Bold().FontSize(14).FontColor(Colors.Blue.Darken2);
                        if (datos.SalesChartImage != null && datos.SalesChartImage.Length > 0)
                        {
                            col.Item().Height(200).Image(datos.SalesChartImage).FitArea();
                        }

                        col.Item().Height(20);

                        col.Item().Row(row =>
                        {
                            // Gráficos Circulares
                            row.RelativeItem().Column(leftCol =>
                            {
                                if (datos.CategoriesChartImage != null && datos.CategoriesChartImage.Length > 0)
                                {
                                    leftCol.Item().Text("Por Categoría").Bold();
                                    leftCol.Item().Height(140).Image(datos.CategoriesChartImage).FitArea();
                                }

                                leftCol.Item().Height(10);

                                if (datos.ProductsChartImage != null && datos.ProductsChartImage.Length > 0)
                                {
                                    leftCol.Item().Text("Por Producto").Bold();
                                    leftCol.Item().Height(140).Image(datos.ProductsChartImage).FitArea();
                                }
                            });

                            row.ConstantItem(20);

                            // Tabla
                            row.RelativeItem().Column(rightCol =>
                            {
                                rightCol.Item().Text("Ranking Vendedores").Bold().FontSize(14).FontColor(Colors.Blue.Darken2);

                                rightCol.Item().PaddingTop(5).MinimalBox().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(2);  // Nombre más ancho
                                        columns.RelativeColumn(1);  // Ventas
                                        columns.RelativeColumn(1.5f); // Total
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Background(Colors.Blue.Darken3).Padding(5).Text("Vendedor").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Blue.Darken3).Padding(5).AlignRight().Text("Cant.").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Blue.Darken3).Padding(5).AlignRight().Text("Total ($)").FontColor(Colors.White).SemiBold();
                                    });

                                    if (datos.TopSellers != null)
                                    {
                                        uint i = 0;
                                        foreach (var seller in datos.TopSellers)
                                        {
                                            var bgColor = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                                            table.Cell().Background(bgColor).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(seller.SellerName);
                                            table.Cell().Background(bgColor).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).AlignRight().Text(seller.TotalSales.ToString());
                                            table.Cell().Background(bgColor).BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).AlignRight().Text($"${seller.TotalValue:N0}");
                                            i++;
                                        }
                                    }
                                });
                            });
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                    });
                });
            })
            .GeneratePdf(rutaArchivo);
        }

        static IContainer EstiloCeldaHeader(IContainer container)
        {
            return container.Background(Colors.Grey.Lighten3).Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Medium);
        }

        static IContainer EstiloCeldaDato(IContainer container)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten4).Padding(5);
        }

        public void ExportarReporteVendedores(SalesmenReportExportDTO datos, string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Desempeño de Vendedores").Bold().FontSize(20).FontColor(Colors.Blue.Medium);
                            col.Item().Text($"Generado: {datos.FechaGeneracion:g}").FontSize(10).FontColor(Colors.Grey.Medium);
                            col.Item().Text(datos.Periodo).FontSize(12).SemiBold();
                        });
                    });


                    page.Content().PaddingVertical(10).Column(col =>
                    {

                        col.Item().Row(row =>
                        {

                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Ingresos Generados").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"${datos.TotalIngresos:N2}").Bold().FontSize(18).FontColor(Colors.Green.Darken2);
                            });

                            row.ConstantItem(10);


                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Ventas Realizadas").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"{datos.TotalVentas}").Bold().FontSize(18).FontColor(Colors.Blue.Darken2);
                            });

                            row.ConstantItem(10);

                            
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Mejor Vendedor").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text(datos.MejorVendedor).Bold().FontSize(14).FontColor(Colors.Orange.Darken2);
                            });
                        });

                        col.Item().Height(20);

                        // TABLA 
                        col.Item().Text("Detalle por Vendedor").Bold().FontSize(14).FontColor(Colors.Blue.Darken2);

                        col.Item().PaddingTop(5).Table(table =>
                        {
                            
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2); // Vendedor (más ancha)
                                columns.RelativeColumn();  // Ventas
                                columns.RelativeColumn();  // Canceladas
                                columns.RelativeColumn(1.5f); // Ingresos
                            });

                            // Encabezados
                            table.Header(header =>
                            {
                                header.Cell().Element(EstiloCeldaHeader).Text("Vendedor");
                                header.Cell().Element(EstiloCeldaHeader).AlignCenter().Text("Ventas");
                                header.Cell().Element(EstiloCeldaHeader).AlignCenter().Text("Canceladas");
                                header.Cell().Element(EstiloCeldaHeader).AlignRight().Text("Ingresos");
                            });

                            // Datos
                            if (datos.DetalleVendedores != null)
                            {
                                uint i = 0;
                                foreach (var item in datos.DetalleVendedores)
                                {
                                    var bgColor = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).Text(item.Vendedor);
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).AlignCenter().Text(item.Ventas.ToString());

                                    // Destacar cancelaciones si son > 0 (opcional)
                                    var colorCanceladas = item.Canceladas > 0 ? Colors.Red.Medium : Colors.Black;
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).AlignCenter().Text(item.Canceladas.ToString()).FontColor(colorCanceladas);

                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).AlignRight().Text(item.Ingresos);

                                    i++;
                                }
                            }
                        });
                    });

                    // --- PIE DE PAGINA ---
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(rutaArchivo);
        }

        public void ExportarReporteProductos(ProductReportExportDTO datos, string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(9));

                    // --- CABECERA ---
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("Reporte de Rendimiento de Productos").Bold().FontSize(20).FontColor(Colors.Blue.Medium);
                            col.Item().Text($"Generado: {datos.FechaGeneracion:g}").FontSize(10).FontColor(Colors.Grey.Medium);
                            col.Item().Text(datos.Periodo).FontSize(12).SemiBold();

                            
                            if (datos.FiltroCategoria != "Todas" || datos.FiltroProveedor != "Todos")
                            {
                                col.Item().PaddingTop(5).Border(1).BorderColor(Colors.Orange.Medium).Background(Colors.Orange.Lighten5).Padding(5).Text(txt =>
                                {
                                    txt.Span("⚠️ Filtros aplicados: ").Bold().FontColor(Colors.Orange.Darken2);

                                    if (datos.FiltroCategoria != "Todas")
                                        txt.Span($"[Categoría: {datos.FiltroCategoria}] ").SemiBold();

                                    if (datos.FiltroProveedor != "Todos")
                                        txt.Span($"[Proveedor: {datos.FiltroProveedor}] ").SemiBold();
                                });
                            }
                        });
                    });

                    // --- CONTENIDO ---
                    page.Content().PaddingVertical(10).Column(col =>
                    {

                        col.Item().Row(row =>
                        {

                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Ingresos Totales").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"${datos.TotalIngresos:N2}").Bold().FontSize(16).FontColor(Colors.Green.Darken2);
                            });
                            row.ConstantItem(10);


                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Unidades Vendidas").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"{datos.TotalUnidades}").Bold().FontSize(16).FontColor(Colors.Blue.Darken2);
                            });
                            row.ConstantItem(10);

    
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("Producto Estrella").Medium().FontColor(Colors.Grey.Darken2);
                                c.Item().Text(txt =>
                                {
                                  
                                    txt.Span(datos.ProductoEstrella)
                                       .Bold()
                                       .FontSize(12)
                                       .FontColor(Colors.Orange.Darken2);

                                    
                                    txt.ClampLines(2);
                                });
                            });
                        });

                        col.Item().Height(15);

                        // TABLA
                        col.Item().Text("Detalle por Producto").Bold().FontSize(14).FontColor(Colors.Blue.Darken2);
                        col.Item().PaddingTop(5).Table(table =>
                        {
                            
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(30); // ID
                                columns.RelativeColumn(3);  // Producto (Ancho)
                                columns.RelativeColumn(2);  // Categoría
                                columns.RelativeColumn(2);  // Proveedor
                                columns.RelativeColumn(1);  // Vendidos
                                columns.RelativeColumn(1);  // Stock
                                columns.RelativeColumn(1.5f); // Ingresos
                            });

                            
                            table.Header(header =>
                            {
                                header.Cell().Element(EstiloCeldaHeader).Text("ID");
                                header.Cell().Element(EstiloCeldaHeader).Text("Producto");
                                header.Cell().Element(EstiloCeldaHeader).Text("Categoría");
                                header.Cell().Element(EstiloCeldaHeader).Text("Proveedor");
                                header.Cell().Element(EstiloCeldaHeader).AlignCenter().Text("Vend.");
                                header.Cell().Element(EstiloCeldaHeader).AlignCenter().Text("Stock");
                                header.Cell().Element(EstiloCeldaHeader).AlignRight().Text("Ingresos");
                            });

                            
                            if (datos.DetalleProductos != null)
                            {
                                uint i = 0;
                                foreach (var item in datos.DetalleProductos)
                                {
                                    var bgColor = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).Text(item.ID.ToString());
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).Text(item.Producto);
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).Text(item.Categoria);
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).Text(item.Proveedor);
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).AlignCenter().Text(item.Vendidos.ToString());

                                    
                                    var stockColor = item.Stock < 5 ? Colors.Red.Medium : Colors.Black;
                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).AlignCenter().Text(item.Stock.ToString()).FontColor(stockColor);

                                    table.Cell().Background(bgColor).Element(EstiloCeldaDato).AlignRight().Text(item.Ingresos);

                                    i++;
                                }
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                    });
                });
            })
            .GeneratePdf(rutaArchivo);
        }


        private class PlaceholderKpi : IComponent
        {
            public void Compose(IContainer container)
            {
                
                container.Padding(10).Column(c => {
                });
            }
        }
    }


}