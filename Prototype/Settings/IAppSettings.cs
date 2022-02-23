using Infrastructure.Settings.Sections;
using System;

namespace Infrastructure.Settings
{
    public interface IAppSettings
    {
        string _DateFormat { get; set; }
        string _DateTimeFormat { get; set; }
        string _DefaultGene { get; set; }
        string _DefaultVida { get; set; }
        string _ServerCulture { get; set; }
        string _TimeFormat { get; set; }
        ConfigServices ConfigServices { get; set; }
        Guid Id { get; }
    }
}