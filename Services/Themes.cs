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
        public static Color ColorBack;
        public static Color ColorBackHighlighted;
        public static Color ColorBack2;
        public static Color ColorBack2Highlighted;
        public static Color ColorPrimary;
        public static Color ColorPrimaryHighlighted;
        public static Color ColorSecondary;
        public static Color ColorSecondaryHighlighted;
        public static Color ColorHighlight;
        public static Color ColorHighlightHighlighted;
        public static Color ColorWarning;
        public static Color ColorWarningHighlighted;
        public static Color ColorNormalText;
        public static Image LogoImage;

        public static void SetLightTheme()
        {
            LogoImage = Properties.Resources.VentasAppLogoClaro;
            ColorNormalText = Color.Black;
            // Fondos (Backgrounds)
            ColorBack = Color.FromArgb(240, 246, 255);       // F0F6FF
            ColorBackHighlighted = Color.FromArgb(229, 239, 255);    // E5EFFF
            ColorBack2 = Color.FromArgb(229, 239, 255);        // E5EFFF
            ColorBack2Highlighted = Color.FromArgb(216, 229, 247);   // D8E5F7

            // Acciones y Datos (Actions and Data)
            ColorPrimary = Color.FromArgb(126, 183, 244);      // 4285F4
            ColorPrimaryHighlighted = Color.FromArgb(43, 108, 218); // 2B6CDA
            ColorSecondary = Color.FromArgb(117, 169, 249);    // 75A9F9
            ColorSecondaryHighlighted = Color.FromArgb(88, 144, 224);// 5890E0

            // Estados (States)
            ColorHighlight = Color.FromArgb(110, 200, 210);    // A6EFA6
            ColorHighlightHighlighted = Color.FromArgb(138, 223, 138);// 8ADF8A
            ColorWarning = Color.FromArgb(244, 180, 180);      // F4B4B4
            ColorWarningHighlighted = Color.FromArgb(218, 154, 154); // DA9A9A
        }

        public static void SetDarkTheme()
        {
            LogoImage = Properties.Resources.VentasAppLogoOscuro;
            ColorNormalText = Color.White;

            // Fondos (Backgrounds)
            ColorBack = Color.FromArgb(30, 42, 56);         // 1E2A38
            ColorBackHighlighted = Color.FromArgb(40, 56, 72);      // 283848
            ColorBack2 = Color.FromArgb(40, 56, 72);          // 283848
            ColorBack2Highlighted = Color.FromArgb(58, 77, 99);     // 3A4D63

            // Acciones y Datos (Actions and Data)
            ColorPrimary = Color.FromArgb(66, 133, 244);        // 4285F4
            ColorPrimaryHighlighted = Color.FromArgb(97, 155, 248);   // 619BF8
            ColorSecondary = Color.FromArgb(138, 180, 248);      // 8AB4F8
            ColorSecondaryHighlighted = Color.FromArgb(163, 198, 255);  // A3C6FF

            // Estados (States)
            ColorHighlight = Color.FromArgb(128, 196, 210);      // 6AA86A
            ColorHighlightHighlighted = Color.FromArgb(133, 198, 133);  // 85C685
            ColorWarning = Color.FromArgb(199, 96, 96);        // C76060
            ColorWarningHighlighted = Color.FromArgb(229, 127, 127);   // E57F7F
        }
    }
}
