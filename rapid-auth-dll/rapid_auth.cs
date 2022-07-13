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
        public static string OPENSSL_KEY = "";


        public static string sign_in(string username, string password)
        {
            string response_string;
            
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["api_key"] = API_KEY;
                values["username"] = crypting.EncryptString(username);
                values["password"] = crypting.EncryptString(password);
                
                //HWID
                values["windows_username"] = crypting.EncryptString(Environment.UserName);
                
                values["gpu_name"] = crypting.EncryptString(hwid.gpu()[0]);
                
                values["gpu_ram"] = crypting.EncryptString(hwid.gpu()[1]);
                
                values["drive_count"] = crypting.EncryptString(hwid.drive_count().ToString());
                values["cpu_name"] = crypting.EncryptString(hwid.cpu()[0]);
                values["cpu_cores"] = crypting.EncryptString(hwid.cpu()[1]);
                values["os_caption"] = crypting.EncryptString(hwid.os_info()[0]);
                values["os_serial_number"] = crypting.EncryptString(hwid.os_info()[1]);

                
                var response = client.UploadValues("http://localhost/rapid_auth_api/loader_users/sign_in.php", values);

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
                values["username"] = crypting.EncryptString(username);
                values["password"] = crypting.EncryptString(password);

                //HWID
                values["windows_username"] = crypting.EncryptString(Environment.UserName);

                values["gpu_name"] = crypting.EncryptString(hwid.gpu()[0]);

                values["gpu_ram"] = crypting.EncryptString(hwid.gpu()[1]);

                values["drive_count"] = crypting.EncryptString(hwid.drive_count().ToString());
                values["cpu_name"] = crypting.EncryptString(hwid.cpu()[0]);
                values["cpu_cores"] = crypting.EncryptString(hwid.cpu()[1]);
                values["os_caption"] = crypting.EncryptString(hwid.os_info()[0]);
                values["os_serial_number"] = crypting.EncryptString(hwid.os_info()[1]);


                var response = client.UploadValues("http://localhost/rapid_auth_api/loader_users/sign_up.php", values);

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
                values["username"] = crypting.EncryptString(username);
                values["password"] = crypting.EncryptString(password);


                var response = client.UploadValues("http://localhost/rapid_auth_api/loader_users/get_active_keys.php", values);
                response_string = crypting.DecryptString(Encoding.Default.GetString(response));
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
                values["username"] = crypting.EncryptString(username);
                values["password"] = crypting.EncryptString(password);
                values["license_key"] = crypting.EncryptString(license_key);

                var response = client.UploadValues("http://localhost/rapid_auth_api/loader_users/redeem_key.php", values);

                response_string = crypting.DecryptString(Encoding.Default.GetString(response));
            }

            return response_string;
        }
    }
}
