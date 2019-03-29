using System;
using System.Collections.Generic;
using System.Text;

namespace DSUL
{
    public interface ITextFileHelper
    {
        void SaveTextFile(string filename, string content);
        string LoadTextFile(string filename);
    }
}
