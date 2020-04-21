using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Snake_2._0
{
    public class Params
    {
        private string resoucesFloder;
        
        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal);
            string binFolder =
                Directory.GetCurrentDirectory().ToString().Substring(0, ind)
                .ToString();

            resoucesFloder = binFolder + "resources\\";
        }

        public string GetResourceFolder()
        {
            return resoucesFloder;
        }
    }
}
