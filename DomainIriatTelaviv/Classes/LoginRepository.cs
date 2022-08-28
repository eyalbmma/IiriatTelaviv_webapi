using DomainIriatTelaviv.BaseRepository.Interfaces;
using DomainIriatTelaviv.Entities;
using DomainIriatTelaviv.Interfaces;
using DomainIriatTelaviv.Res_Req.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainIriatTelaviv.Classes
{
    public class LoginRepository : IloginRepository
    {
        public readonly IRepository<TelAvivContext> repository;

        public LoginRepository(IRepository<TelAvivContext> _repository)
        {
            repository = _repository;
        }

        public LoginResult Login(Users model)
        {
            try
            {
                int num = 1;
                var res = repository.GetFirstObject<Users>(x => x.Email == model.Email && x.Password == model.Password);// && x.Password == model.Password x.Email == "admin@abc.com




                LoginResult loginResult = new LoginResult();


                loginResult.success = true;
                loginResult.id = res.id;
                return loginResult;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
