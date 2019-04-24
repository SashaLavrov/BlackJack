using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Nickname { get; set; }

        public bool IsBot { get; set; }

        public IEnumerable<Combination> Combinations { get; set; }
    }
}
