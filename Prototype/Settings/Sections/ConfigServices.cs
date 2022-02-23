using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Settings.Sections
{
    public class ConfigServices
    {
        public string _BaseAddress { get; set; }
        public string _RemoteRoute { get; set; }
        public bool _isEnableLog { get; set; }
        public string _LogPath { get; set; }
    }
}
