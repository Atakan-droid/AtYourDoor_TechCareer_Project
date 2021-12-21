using AuthManager.Entities;
using Business.Abstract;
using Business.Utilities.Messages;
using Business.Utilities.Result;
using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager:IAddressService
    {
        private readonly ICityDal _cityDal;
        private readonly ICountyDal _countyDal;
        private readonly IAddressDal _addressDal;
        private readonly IUserDal _userDal;
        public AddressManager(ICityDal cityDal, ICountyDal countyDal,IAddressDal addressDal,IUserDal userDal)
        {
            _cityDal = cityDal;
            _countyDal = countyDal;
            _addressDal = addressDal;
            _userDal = userDal;
            
        }

        public Result<Address> AddAddress(Address address)
        {
             
            if (!CheckUserExist(address.UserId))
            { return new Result<Address>(false, Messages.UserNotFound); }
            var result = _userDal.Get(r => r.Role.Role == "Uye" && r.Id==address.UserId);
            
            if (result != null)
            {
                return AddAddressForAvalibleServiceArea(address);
            }

              _addressDal.Add(address);
            GetUserForChangeActivity(address.UserId);
            return new Result<Address>(address, true, Messages.AddressAdded);
        }
        public Result<Address> AddAddressForAvalibleServiceArea(Address address)
        {
            bool isCourierExist = _userDal.GetCourierWithCounty(address.CountyId);
            if (!isCourierExist) { return new Result<Address>(false, Messages.ServiceNotAvalible); }
            _addressDal.Add(address);
            GetUserForChangeActivity(address.UserId);
            return new Result<Address>(address, true, Messages.AddressAdded);
        }

        public Result<Address> DeleteAddress(int addressId)
        {
            if (CheckAddressExist(addressId))
            {
                Address address = _addressDal.Get(a => a.Id == addressId);
                address.IsDeleted = true;
                _addressDal.Update(address);
                return new Result<Address>(true, Messages.AddressDeleted);
            }
            return new Result<Address>(false,Messages.AddressNotFound);
        }

        public Result<List<Address>> GetAddressByCity(int cityId)
        {
            if (CheckCityExist(cityId))
            {
                var result = _addressDal.GetAddressByCityId(cityId);
                new Result<List<Address>>(result,true, Messages.AddressGet);
            }
            return new Result<List<Address>>(false, Messages.AddressNotFound);
        }

        public Result<List<Address>> GetAddressByCounty(int countyId)
        {
            if (CheckCountyExist(countyId))
            {
               var result =_addressDal.GetAll(a => a.CountyId == countyId);
                new Result<List<Address>>(result,true, Messages.AddressGet);
            }
            return new Result<List<Address>>(false,Messages.AddressNotFound);
        }

        public Result<Address> GetAddressById(int addressId)
        {
            if (CheckAddressExist(addressId))
            {
                var result = _addressDal.Get(a=>a.Id==addressId);
                return new Result<Address>(result, true, Messages.AddressGet);
            }
            return new Result<Address>(false, Messages.AddressNotFound);
        }

        public Result<Address> HardDeleteAddress(int addressId)
        {
            if (CheckAddressExist(addressId))
            {
                Address address = _addressDal.Get(a => a.Id == addressId);
                _addressDal.Delete(address);
                return new Result<Address>(true, Messages.AddressDeleted);
            }
            return new Result<Address>(false, Messages.AddressNotFound);
        }

        public Result<Address> UpdateAddress(int addressId, Address address)
        {
          
                var result = _addressDal.Get(a => a.Id == addressId);
            if (result==null) {
                return new Result<Address>(false, Messages.AddressNotFound);
            }
           
           
            result.CountyId = address.CountyId;
            result.Description = address.Description;
            result.ModifiedDate = DateTime.Now;
            result.UserId = address.UserId;
            _addressDal.Update(result);
            return new Result<Address>(result, true, Messages.AddressUpdated);

        }
        public Result<List<Address>> GetAddressByUser(int userId)
        {
            if (CheckUserExist(userId))
            {
                var result = _addressDal.GetAll(a => a.UserId == userId);
                return new Result<List<Address>>(result, true, Messages.AddressGet);
            }
            return new Result<List<Address>>(false, Messages.AddressNotFound);
        }

        private bool CheckCityExist(int cityId)
        {
            return _cityDal.Any(c => c.Id == cityId);
        }
        private bool CheckCountyExist(int countyId)
        {
            return _countyDal.Any(c => c.Id == countyId);
        }
        private bool CheckAddressExist(int addressId)
        {
            return _addressDal.Any(c => c.Id == addressId);
        }
        private bool CheckUserExist(int userId)
        {
            return _userDal.Any(u => u.Id == userId);
        }
        private void GetUserForChangeActivity(int userId)
        {
            User user = _userDal.Get(u => u.Id == userId);
            if (user.isActive == false)
            {
                user.isActive = true;
                _userDal.Update(user);
            }
        }

     
    }
}
