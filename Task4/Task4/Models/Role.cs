using System.Web.Mvc;
using Task4.Infrastructure;

namespace Task4.Models
{
    [ModelBinder(typeof(RoleModelBinder))]
    public enum Role
    {
        Admin,
        User,
        Guest
    }
}