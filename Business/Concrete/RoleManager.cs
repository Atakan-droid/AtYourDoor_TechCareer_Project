using AuthManager.Entities;
using Business.Abstract;
using Business.Utilities.Messages;
using Business.Utilities.Result;
using Business.Validation.FluentValidation;
using Data.Abstract;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public Result<Roles> AddRole(Roles role)
        {
            var validateRole = RoleValidation(role);
            if (validateRole.IsValid)
            {
                _roleDal.Add(role);
                return new Result<Roles>(role, true, Messages.RoleAdded);
            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var error in validateRole.Errors)
                {
                    errorList.Add(error.PropertyName + " : " + error.ErrorMessage);
                }
                return new Result<Roles>(errorList, false, Messages.RoleError);
            }
        }

        public Result<Roles> DeleteRole(int roleId)
        {
            var role = GetRoleById(roleId);
            if (role != null)
            {
                role.Data.IsDeleted = true;
                role.Data.ModifiedDate = DateTime.Now;
                _roleDal.Update(role.Data);
                return new Result<Roles>(role.Data, true, Messages.RoleDeleted);
            }
            else
            {
                return new Result<Roles>(false, Messages.RoleNotFound);
            }
        }
        public Result<Roles> GetRoleById(int roleId)
        {
            Roles role = _roleDal.Get(r => r.Id == roleId && r.IsDeleted == false);
            if (role != null)
            {
                return new Result<Roles>(role, true, Messages.RoleGet);
            }
            else
            {
                return new Result<Roles>(false, Messages.RoleNotFound);
            }
        }

        public Result<List<Roles>> GetRoles()
        {
            return new Result<List<Roles>>(_roleDal.GetAll(r=>r.IsDeleted==false), true, Messages.RoleGet);
        }

        public Result<Roles> HardDeleteRole(int roleId)
        {
            var role = GetRoleById(roleId);
            if (role != null)
            {
                _roleDal.Delete(role.Data);
                return new Result<Roles>(true, Messages.RoleDeleted);
            }
            else
            {
                return new Result<Roles>(false, Messages.RoleNotFound);
            }
        }

        public Result<Roles> UpdateRole(int roleId, Roles role)
        {
           
                var roleToUpdate = GetRoleById(roleId);
                if (roleToUpdate.Success)
                {
                    roleToUpdate.Data.Role = role.Role;
                    roleToUpdate.Data.IsDeleted = role.IsDeleted;
                    roleToUpdate.Data.ModifiedDate = DateTime.Now;
                    _roleDal.Update(roleToUpdate.Data);
                    return new Result<Roles>(roleToUpdate.Data, true, Messages.RoleUpdated);
                }
                return new Result<Roles>(false, Messages.RoleNotFound);
         
        }
        private ValidationResult RoleValidation(Roles roles)
        {
            RoleValidator validationRules = new RoleValidator();
            ValidationResult result = validationRules.Validate(roles);
            return result;
        }
    }
}
