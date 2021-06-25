using BxlForm.DemoSecurity.Models.Client.Data;
using G = BxlForm.DemoSecurity.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Models.Client.Mappers
{
    internal static class Mappers
    {
        #region User Mappers
        internal static G.User ToGlobal(this User entity)
        {
            return new G.User()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd,
                IsAdmin = entity.IsAdmin
            };
        }

        internal static User ToClient(this G.User entity)
        {
            return new User(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.IsAdmin);
        }
        #endregion

        #region Category Mappers
        internal static G.Category ToGlobal(this Category entity)
        {
            return new G.Category()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        internal static Category ToClient(this G.Category entity)
        {
            return new Category(entity.Id, entity.Name);
        }
        #endregion

        #region Contact Mappers
        internal static G.Contact ToGlobal(this Contact entity)
        {
            return new G.Contact()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                CategoryId = entity.CategoryId,
                UserId = entity.UserId
            };
        }

        internal static Contact ToClient(this G.Contact entity)
        {
            return new Contact(entity.Id, entity.LastName, entity.FirstName, entity.Email, entity.CategoryId, entity.UserId);
        }
        #endregion
    }
}
