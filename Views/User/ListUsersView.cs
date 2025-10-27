using System;
using System.Drawing;
using System.Windows.Forms;

namespace VentasApp.Views.User
{
    public partial class ListUsersView : BaseForm, IListUsersView
    {
        public event EventHandler SearchUserEvent;
        public event EventHandler AddUserViewEvent;
        public event EventHandler DeleteUserEvent;
        public event EventHandler RestoreUserEvent;
        public event EventHandler ShowDeletedCheckboxChange;
        public event EventHandler EditUserViewEvent;

        public ListUsersView()
        {
            InitializeComponent();
            SetupEventsHandler();
        }

        public string searchValue
        {
            get { return SearchTextbox.Text; }
            set { SearchTextbox.Text = value; }
        }

        public bool showDeletedUsers
        {
            get { return ShowDeletedCheckbox.Checked; }
            set { ShowDeletedCheckbox.Checked = value; }
        }

        public void SetUsersListBindingSource(BindingSource source)
        {
            dataGridView1.DataSource = source;
        }

        private void SetupEventsHandler()
        {
            SearchTextbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchUserEvent?.Invoke(this, EventArgs.Empty);
            };

            dataGridView1.SelectionChanged += (s, e) =>
            {
                UpdateDeleteButtonState();
                UpdateRestoreButtonState();
                UpdateEditButtonState();
            };

            OpenAddUserViewButton.Click += delegate { AddUserViewEvent?.Invoke(this, EventArgs.Empty); };
            EditUserButton.Click += delegate { EditUserViewEvent?.Invoke(this, EventArgs.Empty); };
            DeleteButton.Click += delegate { DeleteUserEvent?.Invoke(this, EventArgs.Empty); };
            RestoreButton.Click += delegate { RestoreUserEvent?.Invoke(this, EventArgs.Empty); };

            ShowDeletedCheckbox.CheckedChanged += delegate { ShowDeletedCheckboxChange?.Invoke(this, EventArgs.Empty); };

            this.Activated += delegate { SearchUserEvent?.Invoke(this, EventArgs.Empty); };
        }

        public int? GetSelectedUserId()
        {
            if (dataGridView1.CurrentRow != null)
            {
                return (int)dataGridView1.CurrentRow.Cells["Id"].Value;
            }
            return null;
        }

        public (int? Id, bool? Active)? GetSelectedUserInfo()
        {
            if (dataGridView1.CurrentRow != null)
            {
                var userId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;
                bool isActive = dataGridView1.CurrentRow.Cells["Active"].Value == "Activo";
                return (userId, isActive);
            }
            return null;
        }

        private void UpdateDeleteButtonState()
        {
            var selectedUser = GetSelectedUserInfo();
            DeleteButton.Enabled = selectedUser.HasValue && selectedUser.Value.Active == true;
        }

        private void UpdateRestoreButtonState()
        {
            var selectedUser = GetSelectedUserInfo();
            RestoreButton.Enabled = selectedUser.HasValue && selectedUser.Value.Active == false;
        }

        private void UpdateEditButtonState()
        {
            EditUserButton.Enabled = GetSelectedUserId().HasValue;
        }
    }
}