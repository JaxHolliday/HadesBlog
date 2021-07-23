using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HadesBlog.ViewModels
{
    public class MailSettings
    {
        //So we can configure and use smtp server
        //google and etc
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
