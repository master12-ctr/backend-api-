using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Repository
{
    public class UserServices : IUsers
    {
        private UsersdbContext _dbcontext;
    
        public UserServices(UsersdbContext dbContextData) 
        {
            _dbcontext = dbContextData;
        }  
        public ActionResult<User> Signup(User user)
        {
                    // Check if the user already exists
        var existingUser = _dbcontext.User.FirstOrDefault(u => u.UserName == user.UserName);

        if (existingUser != null)
        {
          //  return BadRequest("Username already exists");
            throw new Exception("Username already exists");
        }

        // Add the new user to the database or any other storage
        _dbcontext.User.Add(user);
        _dbcontext.SaveChanges();
        // Return a success response
         return user;
        }

    }
}