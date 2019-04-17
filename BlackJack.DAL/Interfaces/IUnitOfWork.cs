﻿using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Games { get; }
        IRepository<Round> Rounds { get; }
        IRepository<Combination> Combinations { get; }
        IRepository<ComboCard> ComboCards { get; }
        IRepository<Card> Cards{ get; }
        void Save();
    }
}
