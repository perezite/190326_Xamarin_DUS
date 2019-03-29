using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Security.Cryptography;
using System.IO;
using SQLite;

namespace SecureDroid
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            con = new SQLiteConnection(DependencyService.Get<IFileSystemHelper>().GetDBPath());
            con.CreateTable<User>();
            InitDB();
        }
        SQLiteConnection con;

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryUser.Text) || string.IsNullOrWhiteSpace(entryPasswort.Text))
                return;

            // Synchron:
            // AES

            // Userpasswort aus der Page
            AesManaged aes = new AesManaged();

            // IV holen
            if (!App.Current.Properties.ContainsKey("IV"))
            {
                App.Current.Properties.Add("IV", aes.IV);
                App.Current.SavePropertiesAsync();
            }
            aes.IV = (byte[])App.Current.Properties["IV"];

            // Init
            //if (!App.Current.Properties.ContainsKey("Geheimnis"))
            //{
            //    aes.Key = SHA256.Create().ComputeHash(Encoding.Default.GetBytes("1234")); // <--- Geheime Passwort
            //    var enc = Verschlüsseln(aes, "mein geheimnis"); // DisplayAlert

            //    App.Current.Properties.Add("Geheimnis", enc);
            //    App.Current.SavePropertiesAsync();
            //}

            // (Optional bei Bedarf) Geheimnis neu erstellen 
            // aes.Key = SHA256.Create().ComputeHash(Encoding.Default.GetBytes("1234")); // <--- Geheime Passwort
            // App.Current.Properties["Geheimnis"] = Verschlüsseln(aes, "mein geheimnis"); // DisplayAlert
            // App.Current.SavePropertiesAsync();

            aes.Key = SHA256.Create().ComputeHash(Encoding.Default.GetBytes(entryPasswort.Text)); ;

            var user = con.Table<User>().FirstOrDefault(x => x.Username == entryUser.Text);
            if(user is null)
            {
                DisplayAlert("User ist nicht vorhanden", "User ist in der DB nicht vorhanden", "Ok");
                return;
            }

            // Entschlüsseln
            try
            {
                string entschlüsselt = Entschlüsseln(aes, user.PasswortHash);
                DisplayAlert("Entschlüsseltes Geheimnis", entschlüsselt, "Ok");
            }
            catch (Exception)
            {
                DisplayAlert("Falsches Passwort", "Geheimnis konnte nicht entschlüsselt werden", "Ok");
            }
        }

        private void InitDB()
        {
            if(con.Table<User>().Count() == 0)
            {
                AesManaged aes = new AesManaged();

                // IV holen
                if (!App.Current.Properties.ContainsKey("IV"))
                {
                    App.Current.Properties.Add("IV", aes.IV);
                    App.Current.SavePropertiesAsync();
                }
                aes.IV = (byte[])App.Current.Properties["IV"];
                aes.Key = SHA256.Create().ComputeHash(Encoding.Default.GetBytes("12345678"));
                User u1 = new User { Username = "Michi", PasswortHash = Verschlüsseln(aes, "12345678") };
                aes.Key = SHA256.Create().ComputeHash(Encoding.Default.GetBytes("gemüse"));
                User u2 = new User { Username = "Tom Ate", PasswortHash = Verschlüsseln(aes, "gemüse") };
                aes.Key = SHA256.Create().ComputeHash(Encoding.Default.GetBytes("obst"));
                User u3 = new User { Username = "Anna Nass", PasswortHash = Verschlüsseln(aes, "obst") };

                con.Insert(u1);
                con.Insert(u2);
                con.Insert(u3);
            }
        }

        private byte[] Verschlüsseln(AesManaged aes, string plainText)
        {
            var encryptor = aes.CreateEncryptor();

            using (MemoryStream memStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cryptoStream))
                    {
                        sw.Write(plainText);
                    }
                }
                return memStream.ToArray(); // Encrypted
            }
        }
        private string Entschlüsseln(AesManaged aes, byte[] encodedText)
        {
            var decryptor = aes.CreateDecryptor();

            using (MemoryStream memStream = new MemoryStream(encodedText))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cryptoStream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
