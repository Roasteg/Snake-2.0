using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Snake_2._0
{
    public class Time
    {
        public void PlayTime()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"{ts.Minutes:00}:{ts.Seconds:00}");
        }
    }
}