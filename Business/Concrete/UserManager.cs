using AuthManager.Entities;
using AuthManager.Entities.DTOs;
using AuthManager.Utilities.JWT;
using AuthManager.Utilities.Models;
using AutoMapper;
using Business.Abstract;
using Business.Utilities.Messages;
using Business.Utilities.Result;
using Business.Validation.FluentValidation;
using Data.Abstract;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private readonly IRoleDal _roleDal;
        private readonly IJWTToken _token;
        private readonly IOrderDal _orderDal;
        private readonly IAddressDal _addressDal;
        public UserManager(IUserDal userDal, IMapper mapper, IRoleDal roleDal, IJWTToken token,IOrderDal orderDal, IAddressDal addressDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _roleDal = roleDal;
            _token = token;
            _orderDal = orderDal;
            _addressDal = addressDal;
        }
        public Result<UserRegisterDTO> AddUser(UserRegisterDTO user,int roleId)
        {
            bool isRoleExist = _roleDal.Any(r => r.Id == roleId);
            if (!isRoleExist)
            {
                return new Result<UserRegisterDTO>(false, Messages.RoleNotFound);
            }
            var validatedUser = ValidateRegister(user);
            
            if (validatedUser.IsValid)
            {
                var mappedUser = _mapper.Map<User>(user);
                mappedUser.RoleID = roleId;
                _userDal.Add(mappedUser);

                return new Result<UserRegisterDTO>(user, true, Messages.UserAdded);
            }else
            {
                List<string> errorList = new List<string>();
                foreach (var error in validatedUser.Errors)
                {
                    errorList.Add(error.PropertyName + " : " + error.ErrorMessage);
                }
                return new Result<UserRegisterDTO>(errorList, false, Messages.UserError);
            }
        }

        public Result<UserViewDTO> ChangeUserRole(int userId, int roleId)
        {
            var roleChangeUser = GetUserById(userId);
            if (roleChangeUser.Success)
            {
                var role = _roleDal.Get(r => r.Id==roleId);
                if (role != null)
                {
                    roleChangeUser.Data.RoleID = roleId;
                    _userDal.Update(roleChangeUser.Data);
                    return new Result<UserViewDTO>(_mapper.Map<UserViewDTO>(roleChangeUser.Data), true, Messages.UserUpdated);
                }
                else {return new Result<UserViewDTO>(false, Messages.RoleNotFound); }
            }
            else { return new Result<UserViewDTO>(false, Messages.UserNotFound); }
        }

        public Result<UserViewDTO> DeleteUser(int userId)
        {
            var deleteUser = GetUserById(userId);
            if (deleteUser.Success)
            {
                    deleteUser.Data.IsDeleted=true;
                    _userDal.Update(deleteUser.Data);
                    return new Result<UserViewDTO>(true, Messages.UserUpdated);
               
            }
            else { return new Result<UserViewDTO>(false, Messages.UserNotFound); }
        }

        public Result<User> GetUserById(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user == null)
            {
                return new Result<User>(false, Messages.UserNotFound);
            }
            return new Result<User>(user, true, Messages.UserGet);
        }

        public Result<List<UserViewDTO>> GetUsers()
        {
            List<User> user = _userDal.GetAll(u => u.IsDeleted == false);
            List<UserViewDTO> userViewDto = new List<UserViewDTO>();
            foreach (var item in user)
            {
                userViewDto.Add(_mapper.Map<UserViewDTO>(item));
            }
            return new Result<List<UserViewDTO>>(userViewDto, true, Messages.UserGet);
        }

        public Result<List<UserViewDTO>> GetUsersByRoleId(int roleId)
        {
            bool isRoleExist = _roleDal.Any(r=>r.Id==roleId);
            if (isRoleExist)
            {
                List<User> users = _userDal.GetAll(u=>u.RoleID==roleId);
                List<UserViewDTO> userViewDTOs = new List<UserViewDTO>();
                foreach (var item in users)
                {
                    userViewDTOs.Add(_mapper.Map<UserViewDTO>(item));
                }
                return new Result<List<UserViewDTO>>(userViewDTOs, true, Messages.UserGet);

            }
            else { return new Result<List<UserViewDTO>>(false, Messages.UserNotFound); }
        }
        public Result<List<User>> GetUsersByRoleName(string role)
        {
            var isRoleExist = _roleDal.Get(r => r.Role == role);
            if (isRoleExist!=null)
            {
                List<User> users = _userDal.GetAll(u => u.RoleID== isRoleExist.Id);
              
                return new Result<List<User>>(users, true, Messages.UserGet);

            }
            else { return new Result<List<User>>(false, Messages.UserNotFound); }
        }

        public Result<UserViewDTO> HardDeleteUser(int userId)
        {
            User user = GetUserById(userId).Data;
            if (user != null)
            {
                _userDal.Delete(user);
                return new Result<UserViewDTO>(true, Messages.UserDeleted);
            }else {return new Result<UserViewDTO>(false,Messages.UserNotFound); }
        }

        public Result<UserRegisterDTO> UpdateUser(int userId, UserRegisterDTO user,int roleId)
        {
          
         
                bool isRoleExist = _roleDal.Any(r => r.Id == roleId);
                if (!isRoleExist)
                {
                    return new Result<UserRegisterDTO>(false, Messages.RoleNotFound);
                }
                var updateUser = GetUserById(userId);
                if (!updateUser.Success)
                {
                    return new Result<UserRegisterDTO>(false, Messages.UserNotFound);
                }
                var mappedUser = _mapper.Map<User>(user);
                mappedUser.RoleID = roleId;
                mappedUser.Mail = updateUser.Data.Mail;
                mappedUser.Name = updateUser.Data.Name;
                mappedUser.Surname = updateUser.Data.Surname;
                mappedUser.ModifiedDate = DateTime.Now;
                mappedUser.isActive = true;
                _userDal.Add(mappedUser);

                return new Result<UserRegisterDTO>(user, true, Messages.UserAdded);
         
        }

        public Result<UserLoginDTO> UserLogin(UserLoginDTO user)
        {
            var validatedUser = ValidateLogin(user);
            if (validatedUser.IsValid)
            {
                var userToCheck = _userDal.Get(u=>u.Mail==user.Mail);
                if (userToCheck == null)
                {
                    
                    return new Result<UserLoginDTO>(false,Messages.UserNotFound);
                }

                return new Result<UserLoginDTO>(user,true, Messages.SuccesfulLogin);

            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var item in validatedUser.Errors)
                {
                    errorList.Add(item.PropertyName + " : " + item.ErrorMessage);
                }
                return new Result<UserLoginDTO>(errorList, false, Messages.UserError);
            }
        }

        public Result<UserRegisterDTO> UserRegister(UserRegisterDTO user)
        {
            var validatedUser = ValidateRegister(user);
            if (validatedUser.IsValid)
            {
                var getUserRole = _roleDal.Get(r=>r.Role=="Uye");
                var registeredUser = _mapper.Map<User>(user);
                registeredUser.RoleID = getUserRole.Id;
                _userDal.Add(registeredUser);
                return new Result<UserRegisterDTO>(user,true, Messages.UserRegistered);
            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var item in validatedUser.Errors)
                {
                    errorList.Add(item.PropertyName + " : " + item.ErrorMessage);
                }
                return new Result<UserRegisterDTO>(errorList, false, Messages.UserError);
            }
        }
        private ValidationResult ValidateRegister(UserRegisterDTO user)
        {
            UserRegisterDTOValidator rules = new UserRegisterDTOValidator();
            ValidationResult result = rules.Validate(user);
            return result;
        }
        private ValidationResult ValidateLogin(UserLoginDTO user)
        {
            UserLoginDTOValidator rules = new UserLoginDTOValidator();
            ValidationResult result = rules.Validate(user);
            return result;
        }

        public Result<Token> CreateAccessToken(UserLoginDTO user)
        {
            var claim = _userDal.Get(u=>u.Mail==user.Mail);
            var role = _roleDal.Get(r=>r.Id==claim.RoleID);
            var userToLogin = _mapper.Map<User>(user);
            Token accesToken = _token.CreateToken(claim, role);
            return new Result<Token>(accesToken,true, Messages.SuccesfulLogin); ;
        }

        public Result<List<User>> GetAvalibleCouriersWithCountyId(int countyId)
        {
            
            List<User> avalibleCouriers = new List<User>();
          

           var couriers = _userDal.GetCourierWithCountyId(countyId);
            foreach (var item in couriers)
            {
                var orders = _orderDal.GetAll(o=>o.CourierId==item.Id && o.isDelivered==false);
                if (orders.Count==0) { avalibleCouriers.Add(item);}
            }
            if (avalibleCouriers.Count==0)
            {
                return new Result<List<User>>(avalibleCouriers, false, Messages.NoAvalibleCourier);
            }
            else
            {
                return new Result<List<User>>(avalibleCouriers, true, Messages.CourierGet);
            }
           
        }
    }
}
