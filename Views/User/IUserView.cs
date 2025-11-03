using System;
using System.Windows.Forms;

namespace VentasApp.Views.User
{
    public interface IUserView : IBaseForm
    {
        int UserId { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string FullName { get; set; }
        string Role { get; set; }
        int RoleId { get; set; }
        string Phone { get; set; }
        bool IsEditMode { get; set; }

        event EventHandler SaveUserEvent;
        event EventHandler CancelUserEvent;

        void ShowDialogView();
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void CloseView();
        void SetRoleComboBoxDataSource(object dataSource);
    }
}