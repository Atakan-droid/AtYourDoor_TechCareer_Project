using AuthManager.Entities;
using Business.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        Result<Address> AddAddress(Address address);
        Result<Address> UpdateAddress(int addressId,Address address);
        Result<Address> DeleteAddress(int addressId);
        Result<Address> HardDeleteAddress(int addressId);
        Result<List<Address>> GetAddressByCity(int cityId);
        Result<List<Address>> GetAddressByCounty(int countyId);
        Result<List<Address>> GetAddressByUser(int userId);
        Result<Address> GetAddressById(int addressId);
    }
}
