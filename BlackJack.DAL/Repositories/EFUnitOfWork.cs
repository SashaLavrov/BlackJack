using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlackJack.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;
        private GameRepository _gameRepository;
        private RoundRepository _roundRepository;
        private CombinationRepository _combinationRepository;
        private ComboCardRepository _comboCardRepository;
        private CardRepository _cardRepository;

        private UserManager<ApplicationUser> _userManager;
        //private RoleManager<ApplicationUser> _roleManager;

        public EFUnitOfWork(DbContextOptions<ApplicationContext> options)
        {
            _db = new ApplicationContext(options);
            _gameRepository = new GameRepository(_db);
            _roundRepository = new RoundRepository(_db);
            _combinationRepository = new CombinationRepository(_db);
            _comboCardRepository = new ComboCardRepository(_db);
            _cardRepository = new CardRepository(_db);

            //_userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));
        }

        public IRepository<Game> Games
        {
            get { return _gameRepository; }
        }

        public IRepository<Round> Rounds
        {
            get { return _roundRepository; }
        }

        public IRepository<Combination> Combinations
        {
            get { return _combinationRepository; }
        }

        public IRepository<ComboCard> ComboCards
        {
            get { return _comboCardRepository; }
        }

        public IRepository<Card> Cards
        {
            get { return _cardRepository; }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
