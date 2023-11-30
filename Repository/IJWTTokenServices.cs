using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface IJWTTokenServices
    {
        JWTTokens Authenticate(User users);
    }
}