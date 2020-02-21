using System;
using System.Collections.Generic;
using System.Text;
using WD.Entities;

namespace WD.Interfaces
{
    public interface ISecurityService
    {
        User GenerateJWT(User user);
    }
}