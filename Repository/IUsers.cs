using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Repository
{
    public interface IUsers
    {
        ActionResult<User> Signup(User user);
    }
}