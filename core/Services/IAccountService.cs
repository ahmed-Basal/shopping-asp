using core.Dto;
using core.Entities;
using core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Services
{
    public  interface  IAccountService:IAuth
    {

      
        Task SendVerificationCode(AppUser user);

        

       
    }
}
