using System;
using System.Drawing;

namespace VentasApp.Services
{
    public static class Themes
    {
        // Colores de la barra lateral
  public static Color SidebarBackgroundColor;       
    public static Color SidebarButtonColor;
  public static Color SidebarButtonTextColor;
      public static Color SidebarButtonHoverColor;
  public static Color SidebarButtonActiveColor;
    
   // Colores de la vista principal
        public static Color MainViewBackgroundColor;
   public static Color MainViewButtonColor;
    public static Color MainViewButtonTextColor;
  
        // Colores de botones de acción
        public static Color MainActionButtonColor;
      public static Color MainActionButtonTextColor;
 public static Color MainActionButtonHoverColor;

        // Colores de advertencia
     public static Color WarningButtonBackground;
   public static Color WarningButtonTextColor;
     public static Color WarningButtonHoverColor;

        // Colores de éxito
  public static Color SuccessButtonBackground;
        public static Color SuccessButtonTextColor;
   public static Color SuccessButtonHoverColor;

     // Colores de texto
  public static Color ColorNormalText;
  public static Color HighlightTextColor;
   public static Color SubtleTextColor;

        // Colores de bordes y líneas
        public static Color BorderColor;
  public static Color DividerColor;

        // Efectos de brillo
        public static int MouseOverBrightness;
 public static int MouseDownBrightness;

        // Recursos
  public static Image LogoImage;

        // Fuentes
        public static Font HeaderFont;
  public static Font SubHeaderFont;
        public static Font NormalFont;
        public static Font SmallFont;

   public static void SetLightTheme()
   {
 // Imagen del logo
  LogoImage = Properties.Resources.VentasAppLogoClaro;

 MouseOverBrightness = -20; 
MouseDownBrightness = -40;

          // Colores de Texto
       ColorNormalText = Color.FromArgb(33, 33, 33); 
   HighlightTextColor = Color.FromArgb(0, 123, 255); 
   SubtleTextColor = Color.FromArgb(117, 117, 117);

 // Barra Lateral (Sidebar)
 SidebarBackgroundColor = Color.FromArgb(248, 249, 250); 
    SidebarButtonColor = Color.FromArgb(255, 255, 255); 
   SidebarButtonTextColor = Color.FromArgb(73, 80, 87); 
            SidebarButtonHoverColor = Color.FromArgb(233, 236, 239);
  SidebarButtonActiveColor = Color.FromArgb(0, 123, 255);

 // Vista Principal (MainView)
   MainViewBackgroundColor = Color.White;
 MainViewButtonColor = Color.FromArgb(248, 249, 250); 
       MainViewButtonTextColor = Color.FromArgb(73, 80, 87);

// Botón de Acción Principal
            MainActionButtonColor = Color.FromArgb(0, 123, 255); 
        MainActionButtonTextColor = Color.White; 
  MainActionButtonHoverColor = Color.FromArgb(0, 105, 217);

   // Botones de Advertencia/Peligro
 WarningButtonBackground = Color.FromArgb(220, 53, 69); 
  WarningButtonTextColor = Color.White; 
            WarningButtonHoverColor = Color.FromArgb(200, 35, 51);

     // Botones de Éxito
     SuccessButtonBackground = Color.FromArgb(40, 167, 69); 
SuccessButtonTextColor = Color.White;
       SuccessButtonHoverColor = Color.FromArgb(33, 136, 56);

  // Bordes y líneas
            BorderColor = Color.FromArgb(222, 226, 230);
  DividerColor = Color.FromArgb(233, 236, 239);

     // Fuentes
     HeaderFont = new Font("Segoe UI", 18F, FontStyle.Bold);
    SubHeaderFont = new Font("Segoe UI", 14F, FontStyle.Bold);
  NormalFont = new Font("Segoe UI", 10F, FontStyle.Regular);
     SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
  }

  public static void SetDarkTheme()
     {
            // Imagen del logo
       LogoImage = Properties.Resources.VentasAppLogoClaro;

 MouseOverBrightness = +40; 
  MouseDownBrightness = +80;

       // Colores de Texto
  ColorNormalText = Color.FromArgb(233, 236, 239);
     HighlightTextColor = Color.FromArgb(108, 168, 255);
SubtleTextColor = Color.FromArgb(173, 181, 189);

            // Barra Lateral (Sidebar)
SidebarBackgroundColor = Color.FromArgb(33, 37, 41); 
     SidebarButtonColor = Color.FromArgb(52, 58, 64); 
       SidebarButtonTextColor = Color.FromArgb(233, 236, 239); 
       SidebarButtonHoverColor = Color.FromArgb(73, 80, 87);
     SidebarButtonActiveColor = Color.FromArgb(108, 168, 255);

   // Vista Principal (MainView)
      MainViewBackgroundColor = Color.FromArgb(45, 45, 48); 
  MainViewButtonColor = Color.FromArgb(73, 80, 87);
 MainViewButtonTextColor = Color.White;

  // Botón de Acción Principal
        MainActionButtonColor = Color.FromArgb(108, 168, 255);
       MainActionButtonTextColor = Color.FromArgb(33, 37, 41); 
       MainActionButtonHoverColor = Color.FromArgb(88, 148, 235);

// Botones de Advertencia/Peligro
  WarningButtonBackground = Color.FromArgb(220, 53, 69); 
            WarningButtonTextColor = Color.White;
  WarningButtonHoverColor = Color.FromArgb(200, 35, 51);

   // Botones de Éxito
       SuccessButtonBackground = Color.FromArgb(40, 167, 69);
  SuccessButtonTextColor = Color.White;
            SuccessButtonHoverColor = Color.FromArgb(33, 136, 56);

  // Bordes y líneas
 BorderColor = Color.FromArgb(73, 80, 87);
            DividerColor = Color.FromArgb(52, 58, 64);

// Fuentes
       HeaderFont = new Font("Segoe UI", 18F, FontStyle.Bold);
     SubHeaderFont = new Font("Segoe UI", 14F, FontStyle.Bold);
 NormalFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
   }
    }
}
