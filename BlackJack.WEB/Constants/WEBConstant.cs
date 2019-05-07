using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.WEB.WEBConstants
{
    public static class WEBConstant
    {
        const string Diamonds = "https://banner2.kisspng.com/20180418/cdq/kisspng-playing-card-game-suit-clip-art-diamonds-vector-5ad7ef53a0bfd4.8688200515241009476584.jpg";
        const string Hearts = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/Heart_coraz%C3%B3n.svg/1200px-Heart_coraz%C3%B3n.svg.png";
        const string Spades = "https://www.pinclipart.com/picdir/middle/173-1737828_playing-card-ace-of-spades-suit-clip-art.png";
        const string Clubs = "https://images.vexels.com/media/users/3/136043/isolated/preview/d8382eab3404042011244c3a70987c1e-letrero-club-brillante-by-vexels.png";
        const string Default = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Icon-round-Question_mark.svg/1024px-Icon-round-Question_mark.svg.png";

        public static string GetLink(string key)
        {
            if (key == "Diamonds")
            {
                return Diamonds;
            }
            else if (key == "Hearts")
            {
                return Hearts;
            }
            else if (key == "Spades")
            {
                return Spades;
            }
            else if (key == "Clubs")
            {
                return Clubs;
            }
            return Default;
        }
    }
}
