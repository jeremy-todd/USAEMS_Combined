using System;
using System.Collections.Generic;
using System.Text;
using USAEMS.Core.Services;
using USAEMS.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace USAEMS.Infrastructure.Data
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _dbContext;
        public AppUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AppUser> GetAll()
        {
            var Test = _dbContext.AppUsers;//?
                //.ToList();
            return Test;
        }

        public AppUser Get(string id)
        {
            return _dbContext.AppUsers
                .SingleOrDefault(aU => aU.Id == id);
        }

        public AppUser Add(AppUser newAppUser)
        {
            _dbContext.Users.Add(newAppUser);
            _dbContext.SaveChanges();
            return newAppUser;
        }

        public AppUser Update(AppUser updatedAppUser)
        {
            //get the AppUser object in the current list with this id
            var exisitingAppUser = _dbContext.AppUsers.Find(updatedAppUser.Id);

            //return null if the AppUser to update is not found
            if (exisitingAppUser == null) return null;

            //copy the property values from the changed AppUser into the one in the db
            _dbContext.Entry(exisitingAppUser)
                .CurrentValues
                .SetValues(updatedAppUser);

            //update the AppUser and save
            _dbContext.AppUsers.Update(exisitingAppUser);
            _dbContext.SaveChanges();
            return exisitingAppUser;
        }

        public void Remove(AppUser deleteAppUser)
        {
            _dbContext.Users.Remove(deleteAppUser);
            _dbContext.SaveChanges();
        }
    }
}