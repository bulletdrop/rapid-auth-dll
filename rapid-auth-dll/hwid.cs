using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace rapid_auth_dll
{
    public class hwid
    {
        public static string[] gpu()
        {
            string[] gpu_info = new string[2];
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name, AdapterRAM FROM Win32_VideoController");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                gpu_info[0] = Convert.ToString(queryObj["Name"]);
                gpu_info[1] = Convert.ToString(queryObj["AdapterRAM"]);
            }
            return gpu_info;
        }

        public static string[] cpu()
        {
            string[] cpu_info = new string[2];
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                cpu_info[0] = Convert.ToString(obj["Name"]);
                cpu_info[1] = Convert.ToString(obj["NumberOfCores"]);
            }

            return cpu_info;
        }

        public static int drive_count()
        {
            int drive_count = 0;
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                drive_count++;
            }

            return drive_count;
        }

        public static string[] os_info()
        {
            string[] os_info = new string[2];
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("SELECT Caption, SerialNumber FROM Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                os_info[0] = Convert.ToString(obj["Caption"]);
                os_info[1] = Convert.ToString(obj["SerialNumber"]);
                break;
            }

            return os_info;
        }
    }
}
