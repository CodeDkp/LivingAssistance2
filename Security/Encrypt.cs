using System.Security.Cryptography;
using System.Text;

namespace LivingAssistance2.Security
{
    public class Encrypt
    {
        public static string GeneratePassword(int length) //length of salt    
        {
            //var a = int.Parse(length);
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            //var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string EncodePassword(string pass, string salt) //encrypt password    
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);    
            //return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
    }
}
