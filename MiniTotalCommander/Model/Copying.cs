using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniTotalCommander.Model
{
    static class Copying
    {
        public static void copyFile(string file, string destination)
        {
            try
            {
                File.Copy(file, destination, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
