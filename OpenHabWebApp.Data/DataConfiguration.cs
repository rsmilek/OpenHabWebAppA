using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHabWebApp.Data
{
    public class DataConfiguration
    {
        public const string Section = "Database";

        public string ConnectionString { get; set; } = "Data Source = OpenhabWebAppData.db;";
    }
}
