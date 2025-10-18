using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VentasApp.Models;
using VentasApp.Models.DTOs;

namespace VentasApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(AddUserDTO userDTO)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    var user = new UserModel
                    {
                        Username = userDTO.Username,
                        Email = userDTO.Email,
                        PasswordHash = HashPassword(userDTO.Password),
                        FullName = userDTO.FullName,
                        RoleId = userDTO.RoleId,
                        Phone = userDTO.Phone,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Active = true
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log más detallado del error
                throw new Exception($"Error al agregar usuario: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public IEnumerable<UserModel> GetActiveUsers(bool activeState)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.Where(u => u.Active == activeState).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuarios activos: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                        user.Active = false; // Soft delete
                        user.UpdatedAt = DateTime.Now;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar usuario: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public void RestoreUser(int id)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                        user.Active = true;
                        user.UpdatedAt = DateTime.Now;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar usuario: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los usuarios: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public UserModel GetUserById(int id)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por ID: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public UserModel GetUserByUsername(string username)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.FirstOrDefault(u => u.Username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por username: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public UserModel GetUserByEmail(string email)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.FirstOrDefault(u => u.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario por email: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public IEnumerable<UserModel> SearchUsers(string searchTerm)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.Where(u =>
                        u.Username.Contains(searchTerm) ||
                        u.FullName.Contains(searchTerm) ||
                        u.Email.Contains(searchTerm) ||
                        u.Id.ToString().Contains(searchTerm)
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar usuarios: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public IEnumerable<UserModel> SearchUsers(string searchTerm, bool activeState)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return context.Users.Where(u =>
                        (u.Username.Contains(searchTerm) ||
                         u.FullName.Contains(searchTerm) ||
                         u.Email.Contains(searchTerm) ||
                         u.Id.ToString().Contains(searchTerm)) &&
                        u.Active == activeState
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar usuarios con estado: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public void UpdateUser(UpdateUserDTO userDTO)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    var existingUser = context.Users.Find(userDTO.Id);
                    if (existingUser != null)
                    {
                        existingUser.Username = userDTO.Username;
                        existingUser.Email = userDTO.Email;
                        existingUser.FullName = userDTO.FullName;
                        existingUser.RoleId = userDTO.RoleId;
                        existingUser.Phone = userDTO.Phone;
                        existingUser.UpdatedAt = DateTime.Now;

                        // Solo actualizar password si se proporciona uno nuevo
                        if (!string.IsNullOrEmpty(userDTO.Password))
                        {
                            existingUser.PasswordHash = HashPassword(userDTO.Password);
                        }

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar usuario: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public int? ValidateUser(string username, string password)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username && u.Active);
                    if (user != null)
                    {
                        if (VerifyPassword(password, user.PasswordHash))
                        {
                            return user.Id;
                        }
                        
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar usuario: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public bool IsUsernameAvailable(string username)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return !context.Users.Any(u => u.Username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar disponibilidad de username: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        public bool IsEmailAvailable(string email)
        {
            try
            {
                using (var context = new VentasDBContext())
                {
                    return !context.Users.Any(u => u.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar disponibilidad de email: {ex.Message}. Inner Exception: {ex.InnerException?.Message}", ex);
            }
        }

        // Métodos privados para manejo de passwords
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hashedPassword = HashPassword(password);
            return hashedPassword == hash;
        }
    }
}