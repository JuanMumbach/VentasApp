using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VentasApp.Services
{
    public static class ColorThemes
    {
        public static Color Back;
        public static Color BackHighlighted;
        public static Color Back2;
        public static Color Back2Highlighted;
        public static Color Primary;
        public static Color PrimaryHighlighted;
        public static Color Secondary;
        public static Color SecondaryHighlighted;
        public static Color Highlight;
        public static Color HighlightHighlighted;
        public static Color Warning;
        public static Color WarningHighlighted;
        public static Color NormalText;
        public static Image LogoImage;

        public static void SetLightTheme()
        {
            LogoImage = Properties.Resources.VentasAppLogoClaro;
            NormalText = Color.Black;
            // Fondos (Backgrounds)
            Back = Color.FromArgb(240, 246, 255);       // F0F6FF
            BackHighlighted = Color.FromArgb(229, 239, 255);    // E5EFFF
            Back2 = Color.FromArgb(229, 239, 255);        // E5EFFF
            Back2Highlighted = Color.FromArgb(216, 229, 247);   // D8E5F7

            // Acciones y Datos (Actions and Data)
            Primary = Color.FromArgb(126, 183, 244);      // 4285F4
            PrimaryHighlighted = Color.FromArgb(43, 108, 218); // 2B6CDA
            Secondary = Color.FromArgb(117, 169, 249);    // 75A9F9
            SecondaryHighlighted = Color.FromArgb(88, 144, 224);// 5890E0

            // Estados (States)
            Highlight = Color.FromArgb(110, 200, 210);    // A6EFA6
            HighlightHighlighted = Color.FromArgb(138, 223, 138);// 8ADF8A
            Warning = Color.FromArgb(244, 180, 180);      // F4B4B4
            WarningHighlighted = Color.FromArgb(218, 154, 154); // DA9A9A
        }

        public static void SetDarkTheme()
        {
            LogoImage = Properties.Resources.VentasAppLogoOscuro;
            NormalText = Color.White;

            // Fondos (Backgrounds)
            Back = Color.FromArgb(30, 42, 56);         // 1E2A38
            BackHighlighted = Color.FromArgb(40, 56, 72);      // 283848
            Back2 = Color.FromArgb(40, 56, 72);          // 283848
            Back2Highlighted = Color.FromArgb(58, 77, 99);     // 3A4D63

            // Acciones y Datos (Actions and Data)
            Primary = Color.FromArgb(66, 133, 244);        // 4285F4
            PrimaryHighlighted = Color.FromArgb(97, 155, 248);   // 619BF8
            Secondary = Color.FromArgb(138, 180, 248);      // 8AB4F8
            SecondaryHighlighted = Color.FromArgb(163, 198, 255);  // A3C6FF

            // Estados (States)
            Highlight = Color.FromArgb(128, 196, 210);      // 6AA86A
            HighlightHighlighted = Color.FromArgb(133, 198, 133);  // 85C685
            Warning = Color.FromArgb(199, 96, 96);        // C76060
            WarningHighlighted = Color.FromArgb(229, 127, 127);   // E57F7F
        }
    }
}
