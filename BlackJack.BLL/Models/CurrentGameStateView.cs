using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class CurrentPlayerStateView
    {
        public int RoundNumber { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public bool IsBot { get; set; }
        public IEnumerable<CurrentCardPlayerStateViewItem> Cards { get; set; }
        public int TotalCount { get; set; }
    }

    public class CurrentCardPlayerStateViewItem
    {
        public int CardId { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public string Suit { get; set; }
    }
}
