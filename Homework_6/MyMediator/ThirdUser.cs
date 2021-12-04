using System;
using System.Collections.Generic;
using System.Text;

namespace MyMediator
{
    class ThirdUser:User
    {
        public ThirdUser(MessengerMediator messenger, string username) : base(messenger, username) { }
    }
}
