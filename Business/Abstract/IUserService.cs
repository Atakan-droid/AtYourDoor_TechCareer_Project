using AuthManager.Entities;
using AuthManager.Entities.DTOs;
using AuthManager.Utilities.Models;
using Business.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Result<UserRegisterDTO> UserRegister(UserRegisterDTO user);
        Result<UserLoginDTO> UserLogin(UserLoginDTO user);
        Result<UserRegisterDTO> AddUser(UserRegisterDTO user,int roleId);
        Result<UserRegisterDTO> UpdateUser(int userId, UserRegisterDTO user,int roleId);
        Result<UserViewDTO> DeleteUser(int userId);
        Result<UserViewDTO> HardDeleteUser(int userId);
        Result<User> GetUserById(int userId);
        Result<List<UserViewDTO>> GetUsersByRoleId(int roleId);
        Result<List<User>> GetUsersByRoleName(string role);
        Result<List<User>> GetAvalibleCouriersWithCountyId(int countyId);
        Result<List<UserViewDTO>> GetUsers();
        Result<UserViewDTO> ChangeUserRole(int userId,int roleId);
        Result<Token> CreateAccessToken(UserLoginDTO user);

    }
}
