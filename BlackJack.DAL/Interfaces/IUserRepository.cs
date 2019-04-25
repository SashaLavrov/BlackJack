using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int userId);
        User Get(string userName);
        int Create(string name);
    }
}
