using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VentasApp.Services
{
    public static class Themes
    {
        public static Color SidebarBackgroundColor;       
        public static Color SidebarButtonColor;
        public static Color SidebarButtonTextColor;
        
        public static Color MainViewBackgroundColor;
        public static Color MainViewButtonColor;
        public static Color MainViewButtonTextColor;
        
        public static Color MainActionButtonColor;
        public static Color MainActionButtonTextColor;

        public static Color WarningButtonBackground;
        public static Color WarningButtonTextColor;

        public static Color ColorNormalText;
        public static Color HighlightTextColor;

        public static int MouseOverBrightness;
        public static int MouseDownBrightness;

        public static Image LogoImage;

        public static void SetLightTheme()
        {
            // Imagen del logo: usar la versión clara para un fondo claro
            LogoImage = Properties.Resources.VentasAppLogoClaro;

            MouseOverBrightness = -20; MouseDownBrightness = -40;

            // Colores de Texto
            ColorNormalText = Color.Black; // Texto principal en negro para contraste
            HighlightTextColor = Color.FromArgb(0, 123, 255); // Azul brillante para destacar

            // Barra Lateral (Sidebar) - Ligeramente gris claro para distinguirla del fondo principal
            SidebarBackgroundColor = Color.FromArgb(248, 249, 250); // Gris muy claro
            SidebarButtonColor = Color.FromArgb(220, 220, 220); // Gris claro para botones no seleccionados
            SidebarButtonTextColor = Color.Black; // Texto oscuro

            // Vista Principal (MainView) - Fondo blanco puro
            MainViewBackgroundColor = Color.White;
            MainViewButtonColor = Color.FromArgb(220, 220, 220); // Gris claro para botones
            MainViewButtonTextColor = Color.Black; // Texto oscuro

            // Botón de Acción Principal (Main Action) - Azul primario para acción importante
            MainActionButtonColor = Color.FromArgb(0, 123, 255); // Azul
            MainActionButtonTextColor = Color.White; // Texto blanco en botón azul

            // Botones de Advertencia/Peligro (Warning) - Rojo para indicar acción destructiva
            WarningButtonBackground = Color.FromArgb(220, 53, 69); // Rojo
            WarningButtonTextColor = Color.White; // Texto blanco en botón rojo
        }

        public static void SetDarkTheme()
        {
            // Imagen del logo: usar la versión oscura/clara para un fondo oscuro
            LogoImage = Properties.Resources.VentasAppLogoClaro;

            MouseOverBrightness = +40; MouseDownBrightness = +80;

            // Colores de Texto
            ColorNormalText = Color.White; // Texto principal en blanco
            HighlightTextColor = Color.FromArgb(108, 168, 255); // Azul claro para destacar

            // Barra Lateral (Sidebar) - Un gris más oscuro que el fondo principal
            SidebarBackgroundColor = Color.FromArgb(33, 37, 41); // Gris muy oscuro
            SidebarButtonColor = Color.FromArgb(52, 58, 64); // Gris oscuro para botones
            SidebarButtonTextColor = Color.White; // Texto blanco

            // Vista Principal (MainView) - Fondo principal oscuro
            MainViewBackgroundColor = Color.FromArgb(45, 45, 48); // Gris oscuro principal

            MainViewButtonColor = Color.FromArgb(73, 80, 87); // Gris medio para botones
            MainViewButtonTextColor = Color.White; // Texto blanco

            // Botón de Acción Principal (Main Action) - Azul vibrante para acción importante
            MainActionButtonColor = Color.FromArgb(108, 168, 255); // Azul vibrante
            MainActionButtonTextColor = Color.FromArgb(33, 37, 41); // Texto oscuro o negro

            // Botones de Advertencia/Peligro (Warning) - Rojo oscuro para indicar acción destructiva
            WarningButtonBackground = Color.FromArgb(220, 53, 69); // Rojo
            WarningButtonTextColor = Color.White; // Texto blanco
        }
    }
}
