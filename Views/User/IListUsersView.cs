using System;
using System.Windows.Forms;

namespace VentasApp.Views.User
{
    public interface IListUsersView : IBaseForm
    {
        event EventHandler SearchUserEvent;
        string searchValue { get; set; }
        bool showDeletedUsers { get; set; }
        event EventHandler AddUserViewEvent;
        event EventHandler EditUserViewEvent;
        event EventHandler DeleteUserEvent;
        event EventHandler RestoreUserEvent;
        event EventHandler ShowDeletedCheckboxChange;
        
        int? GetSelectedUserId();
        (int? Id, bool? Active)? GetSelectedUserInfo();
        void SetUsersListBindingSource(BindingSource usersList);
        void SetViewOnlyMode();
    }
}