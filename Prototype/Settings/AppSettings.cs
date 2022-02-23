using Infrastructure.Settings.Sections;
using System;

namespace Infrastructure.Settings
{
    public class AppSettings : IAppSettings
    {
        public Guid Id { get; }
        public string _DefaultGene { get; set; }
        public string _DefaultVida { get; set; }
        public string _DateTimeFormat { get; set; }
        public string _DateFormat { get; set; }
        public string _TimeFormat { get; set; }
        public string _ServerCulture { get; set; }
        public ConfigServices ConfigServices { get; set; }
        public AppSettings()
        {
            Id = Guid.NewGuid();
        }
    }
}
