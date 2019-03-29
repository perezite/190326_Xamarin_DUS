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
[assembly: Xamarin.Forms.Dependency(typeof(SecureDroid.Droid.AndroidFileSystemHelper))]
namespace SecureDroid.Droid
{
    class AndroidFileSystemHelper : IFileSystemHelper
    {
        public string GetDBPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "passwords.sqlite");
        }
    }
}