using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAllUsers();
        IEnumerable<UserModel> GetActiveUsers(bool activeState);
        IEnumerable<UserModel> SearchUsers(string searchTerm);
        IEnumerable<UserModel> SearchUsers(string searchTerm, bool activeState);
        UserModel GetUserById(int id);
        UserModel GetUserByUsername(string username);
        UserModel GetUserByEmail(string email);
        void AddUser(AddUserDTO userDTO);
        void UpdateUser(UpdateUserDTO userDTO);
        void DeleteUser(int id);
        void RestoreUser(int id);
        bool ValidateUser(string username, string password);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string email);
    }
}