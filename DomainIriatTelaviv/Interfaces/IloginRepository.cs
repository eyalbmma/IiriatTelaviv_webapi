using DomainIriatTelaviv.Entities;
using DomainIriatTelaviv.Res_Req.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Interfaces
{
   public  interface IloginRepository
    {
        LoginResult Login(Users model);
    }
}
