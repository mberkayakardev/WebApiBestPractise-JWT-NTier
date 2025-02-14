using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services.Concrete.Messages
{
    public static class Messages
    {
        public static class User
        {
            public const string BosBilgileriHatali = "Kullanıcı Adı veya Şifre boş geçilemez"; 
            public const string GirisBilgileriHatali = "Kullanıcı Adı veya Şifre Hatalıdır"; 
            public const string KullaniciKilitli = "Kullanici Hesabi Kilitlenmiştir. "; 
        }
     
        
        
    }
}

