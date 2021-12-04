using System;
using System.Collections.Generic;
using System.Text;

namespace MyMediator
{
    class SecondUser:User
    {
        public SecondUser(MessengerMediator messenger, string username) : base(messenger, username) { }
    }
}
