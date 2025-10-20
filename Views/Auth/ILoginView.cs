using System;

namespace VentasApp.Views.Auth
{
    /// <summary>
    /// Interfaz para la vista de Login.
    /// Define los eventos y propiedades que debe implementar la vista.
    /// </summary>
    public interface ILoginView
    {
        // Propiedades para obtener los datos ingresados
        string Username { get; set; }
        string Password { get; set; }

        // Eventos
        event EventHandler LoginEvent;
        event EventHandler RegisterLinkEvent;
        event EventHandler CancelEvent;

        // Métodos
        void ShowView();
        void CloseView();
        void ShowMessage(string message, string title, bool isError = false);
        void ClearFields();
        void SetLoginEnabled(bool enabled);
    }
}
