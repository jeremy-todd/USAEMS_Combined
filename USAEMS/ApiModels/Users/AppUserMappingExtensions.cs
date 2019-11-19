using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAEMS.Core.Models;

namespace USAEMS.ApiModels
{
    public static class AppUserMappingExtensions
    {
        public static AppUserModel ToApiModel(this AppUser AppUser)
        {
            return new AppUserModel
            {
                Id = AppUser.Id,
                FirstName = AppUser.FirstName,
                LastName = AppUser.LastName,
                SecurityQuestion = AppUser.SecurityQuestion,
                SecurityAnswer = AppUser.SecurityAnswer,
                Email = AppUser.Email,
                PhoneNumber = AppUser.PhoneNumber,
                CarrierId = AppUser.CarrierId,
                Student = AppUser.Student,
                Technical = AppUser.Technical,
                EmployerId = AppUser.EmployerId,
                Active = AppUser.Active
            };
        }

        public static AppUser ToDomainModel(this AppUserModel AppUserModel)
        {
            return new AppUser
            {
                Id = AppUserModel.Id,
                FirstName = AppUserModel.FirstName,
                LastName = AppUserModel.LastName,
                SecurityQuestion = AppUserModel.SecurityQuestion,
                SecurityAnswer = AppUserModel.SecurityAnswer,
                Email = AppUserModel.Email,
                PhoneNumber = AppUserModel.PhoneNumber,
                CarrierId = AppUserModel.CarrierId,
                Student = AppUserModel.Student,
                Technical = AppUserModel.Technical,
                EmployerId = AppUserModel.EmployerId,
                Active = AppUserModel.Active
            };
        }

        public static IEnumerable<AppUserModel> ToApiModels(this IEnumerable<AppUser> AppUsers)
        {
            return AppUsers.Select(a => a.ToApiModel());
        }

        public static IEnumerable<AppUser> ToDomainModels(this IEnumerable<AppUserModel> AppUserModels)
        {
            return AppUserModels.Select(a => a.ToDomainModel());
        }
    }
}