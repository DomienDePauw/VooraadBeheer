using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem
{
    public class AppSettings
    {
        public string DefaultConnection { get; set; }
        public Dictionary<string, string> LogLevel { get; set; }
    }
}