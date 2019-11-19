using System.Collections.Generic;
using USAEMS.Core.Models;

namespace USAEMS.Core.Services
{
    public interface IAppUserService
    {
        AppUser Add(AppUser newAppUser);
        AppUser Update(AppUser updatedAppUser);
        AppUser Get(string id);
        IEnumerable<AppUser> GetAll();
        void Remove(AppUser deleteAppUser);
    }
}