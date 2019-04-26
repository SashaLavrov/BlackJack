using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class CurrentGameStateView
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public bool IsBot { get; set; }
        public IEnumerable<CardCurentGameStateViewItem> Cards { get; set; }
        public int TotalCount
        {
            get
            {
                int sum = 0;
                foreach (var i in Cards)
                {
                    sum += i.Value;
                }
                return sum;
            }
        }
    }

    public class CardCurentGameStateViewItem
    {
        public int CardId { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public string Suit { get; set; }
    }
}
