using System;
using System.Collections.Generic;
using System.Text;

namespace MyMediator
{
    class Messenger : MessengerMediator//ConcreteMediator
    {
        private FirstUser user1;
        private SecondUser user2;
        private ThirdUser user3;
        public FirstUser User1 { set { user1 = value; } }
        public SecondUser User2 { set { user2 = value; } }
        public ThirdUser User3 { set { user3 = value; } }

        public override void Send(string message, User sender)
        {
            if(sender != user1 && sender != user2 && sender != user3)
            {
                throw new NullReferenceException();
            }
            if(sender == user1)
            {
                user2.Notify(message);
                user3.Notify(message);
            }
            else if (sender == user2)
            {
                user1.Notify(message);
                user3.Notify(message);
            }
            else
            {
                user2.Notify(message);
                user1.Notify(message);
            }

        }
    }
}
