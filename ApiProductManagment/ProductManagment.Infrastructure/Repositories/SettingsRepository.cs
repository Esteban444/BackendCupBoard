using ProductManagment.Contracts.Repositories;

namespace ProductManagment.Infrastructure.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        public string this[string key]
        {
            get
            {
                var value = Environment.GetEnvironmentVariable(key);
                return value ?? string.Empty;
            }
        }
    }

}
