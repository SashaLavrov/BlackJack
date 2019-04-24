using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    class UserRepository : IUserRepository
    {
        private ApplicationContext _db;

        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }
        public int Create(string name)
        {
            User user = new User { Nickname = name };
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserId;
        }

        public User Get(int userId)
        {
            return _db.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }
    }
}
