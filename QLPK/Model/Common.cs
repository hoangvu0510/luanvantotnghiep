using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.Model
{
    class Common
    {
        public static string maNhanVien;
        public static int? nhanVienID;
        public static string maBenhNhan;
        public static CBenhNhanModel objBenhNhanM;
        public static int? vaiTroNhanVien;
        public const int Trong = 1;
        public const int QuanTri = 2;
        public const int BacSi = 3;
        public const int TiepNhan = 4;
        public const int ThuNgan = 5;
        public static string maPhieuDDK;
        public static string maPhieuSDDV;
        public static string maPhongBacSi;

        static public string calculateAge(DateTime birthDate, DateTime now)
        {
            birthDate = birthDate.Date;
            now = now.Date;

            var days = now.Day - birthDate.Day;
            if (days < 0)
            {
                var newNow = now.AddMonths(-1);
                days += (int)(now - newNow).TotalDays;
                now = newNow;
            }
            var months = now.Month - birthDate.Month;
            if (months < 0)
            {
                months += 12;
                now = now.AddYears(-1);
            }
            var years = now.Year - birthDate.Year;
            if (years == 0)
            {
                if (months == 0)
                    return days.ToString() + " ngày";
                else
                    return months.ToString() + " tháng";
            }
            return years.ToString() + " tuổi";
        }
        public static Byte[] HashPassword(string password)
        {

            //create the MD5CryptoServiceProvider object we will use to encrypt the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;
            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

            return hashedBytes;
        }

        public static int ConvertToInt(object input)
        {
            try
            {
                return int.Parse(input.ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

}
