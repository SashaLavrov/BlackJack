using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlackJack.BLL.DTO;
using BlackJack.BLL.Infrastructure;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BlackJack.BLL.Services
{
    public class UserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork db)
        {
            Database = db;
        }
    }
}
