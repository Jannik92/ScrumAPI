using System;
using WebApplication1.Models;
using WebApplication1.Data;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace WebApplication1.Services
{
    public class MemberService
    {
        DataModell access;

        public MemberService()
        {
            access = new DataModell();
        }        

        public bool Register(String Username, String Password)
        {
            Member Member = new Member();
            Member.Name = Username;
            Member.Password = HashPassword(Password);
            access.Members.Add(Member);
            try
            {
                access.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }            
        }

        public bool Login(String Username, String Password)
        {
            String Hash = HashPassword(Password);
            var abfrage = from t in access.Members select t;
            abfrage = from t in abfrage where t.Name == Username select t;
            Member Member = abfrage.SingleOrDefault();
            if (Member.Password.Equals(Hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private String HashPassword(String Password)
        {
            String Salt = "PROJEKTMANAGEMENT123!";
            byte[] bytes = Encoding.Unicode.GetBytes(Password);
            byte[] src = Encoding.Unicode.GetBytes(Salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inarray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inarray);
        }
    }
}
