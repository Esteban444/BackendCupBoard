using System;

namespace ProductManagment.Contracts.Repositories
{
    public interface ISettingsRepository
    {
        string this[string key] { get; }
    }
}
