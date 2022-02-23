using Infrastructure.Settings;
using UOW.Interfaces;

namespace UOW.Sybase
{
    public class UOWSybase : IUOW
    {
        private readonly IAppSettings _configuration;

        public UOWSybase(IAppSettings configuration = null)
        {
            _configuration = configuration;
        }

        public IUOWAdapter Create()
        {

            /*
               var connectionString = _configuration == null
                ? _configuration._DefaultGene
                : _configuration.GetValue<string>("_DefaultGene");
            */

            return new UOWSybaseAdapter(_configuration._DefaultGene);
        }
    }
}
