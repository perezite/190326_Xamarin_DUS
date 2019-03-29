using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(DSUL.Droid.AndroidTextFileHelper))]
namespace DSUL.Droid
{
    public class AndroidTextFileHelper : ITextFileHelper
    {
        public string LoadTextFile(string filename)
        {
            // /data/data/com.companyname.whatsapp/cache
            // System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)

            // Interner speicher:
            // Android.OS.Environment. DataDirectory o.Ä.

            string fullpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
            return File.ReadAllText(fullpath);
        }

        public void SaveTextFile(string filename, string content)
        {
            // /data/data/com.companyname.whatsapp/cache
            // System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)

            // Interner speicher:
            // Android.OS.Environment. DataDirectory o.Ä.

            string fullpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
            File.WriteAllText(fullpath, content);
        }
    }
}