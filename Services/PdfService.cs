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
                            col.Item().Text("Resumen Ejecutivo del Dashboard").Bold().FontSize(20).FontColor(Colors.Blue.Medium);
                            col.Item().Text($"Generado el: {datos.FechaGeneracion:g}");
                            col.Item().Text(datos.Periodo).FontSize(12).SemiBold();
                        });
                    });

                    // --- CONTENIDO ---
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        // 1. Gráfico Principal de Ventas
                        col.Item().Text("Evolución de Ventas").Bold().FontSize(14);

                        if (datos.SalesChartImage != null && datos.SalesChartImage.Length > 0)
                        {
                            // CORRECCIÓN AQUÍ: Usamos FitArea() dentro de un contenedor con altura fija
                            // o FitWidth() si queremos altura automática.
                            col.Item()
                               .Height(200)            // Definimos altura máxima
                               .Image(datos.SalesChartImage)
                               .FitArea();             // <--- ESTO EVITA EL ERROR (ajusta la imagen al espacio)
                        }
                        else
                        {
                            col.Item().Text("(Gráfico no disponible)").Italic().FontColor(Colors.Grey.Medium);
                        }

                        col.Item().Height(20); // Espaciador

                        // 2. Sección Dividida: Gráficos Circulares y Top Vendedores
                        col.Item().Row(row =>
                        {
                            // Columna Izquierda: Gráficos de Torta
                            row.RelativeItem().Column(leftCol =>
                            {
                                leftCol.Item().Text("Distribución por Categoría").Bold();
                                if (datos.CategoriesChartImage != null && datos.CategoriesChartImage.Length > 0)
                                {
                                    leftCol.Item()
                                           .Height(150)
                                           .Image(datos.CategoriesChartImage)
                                           .FitArea(); // <--- CORRECCIÓN
                                }

                                leftCol.Item().Height(10);

                                leftCol.Item().Text("Productos Top").Bold();
                                if (datos.ProductsChartImage != null && datos.ProductsChartImage.Length > 0)
                                {
                                    leftCol.Item()
                                           .Height(150)
                                           .Image(datos.ProductsChartImage)
                                           .FitArea(); // <--- CORRECCIÓN
                                }
                            });

                            row.ConstantItem(20); // Espacio entre columnas

                            // Columna Derecha: Tabla de Mejores Vendedores
                            row.RelativeItem().Column(rightCol =>
                            {
                                rightCol.Item().Text("Ranking Vendedores").Bold().FontSize(14);

                                // Usamos MinimalBox para asegurar que la tabla no intente expandirse infinitamente
                                rightCol.Item().PaddingTop(5).MinimalBox().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();   // Nombre
                                        columns.ConstantColumn(50); // Ventas
                                        columns.ConstantColumn(70); // Total
                                    });

                                    // Header Tabla
                                    table.Header(header =>
                                    {
                                        header.Cell().Element(EstiloCeldaHeader).Text("Vendedor");
                                        header.Cell().Element(EstiloCeldaHeader).AlignRight().Text("#");
                                        header.Cell().Element(EstiloCeldaHeader).AlignRight().Text("Total");
                                    });

                                    // Datos Tabla
                                    if (datos.TopSellers != null)
                                    {
                                        foreach (var seller in datos.TopSellers)
                                        {
                                            table.Cell().Element(EstiloCeldaDato).Text(seller.SellerName);
                                            table.Cell().Element(EstiloCeldaDato).AlignRight().Text(seller.TotalSales.ToString());
                                            table.Cell().Element(EstiloCeldaDato).AlignRight().Text($"${seller.TotalValue:N0}");
                                        }
                                    }
                                });
                            });
                        });
                    });

                    // --- PIE DE PAGINA ---
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
    }
}