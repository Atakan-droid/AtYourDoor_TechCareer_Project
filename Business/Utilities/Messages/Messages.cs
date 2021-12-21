using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Messages
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";

        public static string ProductError = "Ürün Hatası";
        public static string ProductUpdated = "Ürün Güncelledi";
        public static string ProductNotFound = "Ürün Bulunamadı";
        public static string ProductGet = "Ürün Getirildi";

        public static string ProductToAddNumberAndStock = "İstenilen Ürün Adeti Mevcut olandan Fazla Olamaz";


        public static string CategoryMustUniqueName = "Kategori Adı Mevcut";
      

        public static string ProductDeleted = "Ürün Silindi";

        public static string CategoryUpdated = "Kategori Güncelledi";

        public static string ProductMustUniqueName = "Ürünün Adı Mevcut";
        

        public static string CategoryNotFound = "Kategori Mevcut değil";
        public static string CategoryError = "Kategori Hatası";
        public static string CategoryGet = "Kategori Getirildi";
        public static string CategoryAdded = "Kategori Eklendi";

        public static string UserPasswordNotEmpty = "Şifre Alanı Boş Olamaz";
        public static string UserPasswordMin8 = "Şifre en az 8 karakter olmalıdır.";
        public static string UserPasswordAtLeastUpper = "Şifrede En az bir adet büyük karakter olmalıdır.";
        public static string UserPasswordAtLeastLower = "Şifrede En az bir adet küçük karakter olmalıdır.";
        public static string UserPasswordAtLeastNumber ="Şifrede En az bir adet sayı karakter olmalıdır.";
        public static string UserMailMustUnique = "Kullanıcı Mail'i Sistemde Mevcut";
        public static string PasswordConformationMustBeRight ="Parola tekrarı aynı olmalıdır.";
        public static string RoleDeleted = "Rol Silindi";
        public static string RoleAdded = "Rol eklendi";
        public static string RoleError = "Rol Hatası";
        public static string RoleGet = "Rol Getirildi";
        public static string RoleUpdated = "Rol Güncelledi";
        public static string RoleNotFound = "Rol mevcut değil";
        public static string UserError = "Kullanıcı Hatası";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string UserUpdated = "Kullanıcı Güncelledi";
        public static string UserGet = "Kullanıcı Getirildi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserLogin = "Başarıyla giriş yapıldı";
        public static string UserRegistered= "Başarıyla kayıt yapıldı";
        public static string SuccesfulLogin = "Başarılı Giriş";

        public static string AddressGet = "Adres getirildi";
        public static string ServiceNotAvalible = "Bulunduğunuz bölgede hizmetimiz yoktur.";

        public static string AddressAdded = "Adres Eklendi";

        public static string AddressNotFound = "Adres Bulunamadı";

        public static string AddressUpdated = "Adres Güncellendi";

        public static string AddressDeleted = "Adres Silindi";

        public static string OrderError = "Sipariş Hatası";
        public static string OrderAdded = "Sipariş Eklendi";

        public static string OrderGet = "Sipariş Getirildi";
        public static string OrderNotFound = "Sipariş Bulunamadı";

        public static string CourierNotExistInArea = "İlgili Bölgede Kargocu Bulunmamakta";

        public static string NoAvalibleCourier = "İlgili Bölgede Müsait Kargocu Bulunmamaktadır.";

        public static string OrderOnTheWay = "Sipariş Yola Çıktı";
        public static string ProductNotEnoughStock = "Yeterli Sayıda Ürün Bulunmamakta";

        public static string CourierGet = "Kuryeler Getirildi";
        public static string OrderDeleted = "Sipariş Silindi";

        public static string AddressWrong = "Hatalı Adres";

        public static string UserNotOrder = "Bu kullanıcı sipariş veremez";

        public static string OrderNotThisCourier = "Bu Sipariş Girilen Kargocuya Atanmamıştır.";

        public static string OrderIsNotReadyToDeliver = "Hazır olmayan bir sipariş teslim edilemez";

        public static string OrderUpdated = "Sipariş Güncellendi";
    }
}
