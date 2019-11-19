using System;
using System.Collections.Generic;
using System.Text;
using USAEMS.Core.Models;

namespace USAEMS.Core.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public AppUser Add(AppUser newAppUser)
        {
            return _appUserRepository.Add(newAppUser);
        }

        public AppUser Get(string id)
        {
            return _appUserRepository.Get(id);
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _appUserRepository.GetAll();
        }

        public void Remove(AppUser deleteAppUser)
        {
            _appUserRepository.Remove(deleteAppUser);
        }

        public AppUser Update(AppUser updatedAppUser)
        {
            return _appUserRepository.Update(updatedAppUser);
        }
    }
}