using BxlForm.DemoSecurity.Models.Global.Data;
using System.Data;

namespace BxlForm.DemoSecurity.Models.Global.Mappers
{
    internal static class DataRecord
    {
        internal static User ToUser(this IDataRecord dataRecord)
        {
            return new User()
            {
                Id = (int)dataRecord["Id"],
                LastName = (string)dataRecord["LastName"],
                FirstName = (string)dataRecord["FirstName"],
                Email = (string)dataRecord["Email"],
                Passwd = null, //On ne renvoit jamais un mot de passe d'une base de données
                IsAdmin = (bool)dataRecord["IsAdmin"]
            };
        }

        internal static Category ToCategory(this IDataRecord dataRecord)
        {
            return new Category()
            {
                Id = (int)dataRecord["Id"],
                Name = (string)dataRecord["Name"]
            };
        }

        public static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact()
            {
                Id = (int)dataRecord["Id"],
                LastName = (string)dataRecord["LastName"],
                FirstName = (string)dataRecord["FirstName"],
                Email = (string)dataRecord["Email"],
                CategoryId = (int)dataRecord["CategoryId"],
                UserId = (int)dataRecord["UserId"]
            };
        }
    }
}
