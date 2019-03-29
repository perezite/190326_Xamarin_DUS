using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// [assembly: Xamarin.Forms.Dependency(typeof(DSUL.WPF.WPFTextFileHelper))]
namespace DSUL.WPF
{
    public class WPFTextFileHelper : ITextFileHelper
    {
        public string LoadTextFile(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void SaveTextFile(string filename, string content)
        {
            File.WriteAllText(filename,content);
        }
    }
}
