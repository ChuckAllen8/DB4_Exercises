using System;
using System.Collections.Generic;
using System.Text;

namespace Playing_Cards
{
    class ComputerPlayer : Player
    {
        public ComputerPlayer(string name)
        {
            Name = name;
            Hand = new CardHand();
        }
    }
}
