using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.APIHelpers
{
    class APIServerStart
    {
        static Process process1 = null;

        /// <summary>
        /// Start the API Server
        /// </summary>
        public static void StartAPIServer()
        {
            var pp = new ProcessStartInfo("cmd.exe", "/C" + ConfigurationManager.AppSettings["ServerCommand"])
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = ConfigurationManager.AppSettings["APIServerPath"],
            };
            process1 = Process.Start(pp);
        }

        /// <summary>
        /// Stop the API Server
        /// </summary>
        public static void StopAPIServer()
        {
            if (process1 != null)
            {
                process1.Close();
            }
        }
    }
}
