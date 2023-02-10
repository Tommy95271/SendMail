using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMail
{
    public class CfgMailService
    {
        /// <summary>
        /// 取得 Email Server IP
        /// </summary>
        /// <param name="is正式"><c>true</c> 正式， <c>false</c> 業演</param>
        /// <returns></returns>
        public async Task<string> GetSysConfigEmailIpAsync(bool is正式 = false)
        {
            if (is正式)
            {
                return "http://192.168.14.27";
            }
            return "http://192.168.72.27";

            //http://192.168.72.27/Mailhunter_app/SendNow.asmx?op=SendNowAPI
            //http://192.168.72.27/mailhunter/
            //http://192.168.14.27/Mailhunter_app/SendNow.asmx?op=SendNowAPI
            //http://192.168.14.27/mailhunter
        }
    }
}
