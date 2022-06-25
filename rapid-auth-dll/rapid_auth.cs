using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Net;
using System.Collections.Specialized;

namespace rapid_auth_dll
{
    public class rapid_auth
    {
        public static string API_KEY = "";
        
        public static string sign_in(string username, string password)
        {
            string response_string;
            
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["api_key"] = API_KEY;
                values["username"] = username;
                values["password"] = password;
                
                //HWID
                values["windows_username"] = Environment.UserName;
                
                values["gpu_name"] = hwid.gpu()[0];
                
                values["gpu_ram"] = hwid.gpu()[1];
                
                values["drive_count"] = hwid.drive_count().ToString();
                values["cpu_name"] = hwid.cpu()[0];
                values["cpu_cores"] = hwid.cpu()[1];
                values["os_caption"] = hwid.os_info()[0];
                values["os_serial_number"] = hwid.os_info()[1];

                
                var response = client.UploadValues("https://www.rapid-auth.pro/rapid_auth_api/loader_users/sign_in.php", values);

                response_string = Encoding.Default.GetString(response);
            }

            return response_string;
        }

        public static string sign_up(string username, string password)
        {
            string response_string;
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["api_key"] = API_KEY;
                values["username"] = username;
                values["password"] = password;

                //HWID
                values["windows_username"] = Environment.UserName;
                values["gpu_name"] = hwid.gpu()[0];
                values["gpu_ram"] = hwid.gpu()[1];
                values["drive_count"] = hwid.drive_count().ToString();
                values["cpu_name"] = hwid.cpu()[0];
                values["cpu_cores"] = hwid.cpu()[1];
                values["os_caption"] = hwid.os_info()[0];
                values["os_serial_number"] = hwid.os_info()[1];


                var response = client.UploadValues("https://www.rapid-auth.pro/rapid_auth_api/loader_users/sign_up.php", values);

                response_string = Encoding.Default.GetString(response);
            }

            return response_string;
        }

        public static string get_active_keys(string username, string password)
        {
            string response_string;
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["api_key"] = API_KEY;
                values["username"] = username;
                values["password"] = password;


                var response = client.UploadValues("https://www.rapid-auth.pro/rapid_auth_api/loader_users/get_active_keys.php", values);

                response_string = Encoding.Default.GetString(response);
            }

            return response_string;
        }

        public static string redeem_license_key(string username, string password, string license_key)
        {
            string response_string;
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["api_key"] = API_KEY;
                values["username"] = username;
                values["password"] = password;
                values["license_key"] = license_key;

                var response = client.UploadValues("https://www.rapid-auth.pro/rapid_auth_api/loader_users/redeem_key.php", values);

                response_string = Encoding.Default.GetString(response);
            }

            return response_string;
        }
    }
}
