using System;

namespace VentasApp.Views.Auth
{
    /// <summary>
    /// Interfaz para la vista de Registro.
    /// Define los eventos y propiedades que debe implementar la vista.
    /// </summary>
    public interface IRegisterView
    {
        // Propiedades para obtener los datos ingresados
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string FullName { get; set; }
        string Phone { get; set; }

        // Eventos
        event EventHandler RegisterEvent;
        event EventHandler CancelEvent;

        // Métodos
        void ShowView();
        void CloseView();
        void ShowMessage(string message, string title, bool isError = false);
        void ClearFields();
        void SetRegisterEnabled(bool enabled);
    }
}
