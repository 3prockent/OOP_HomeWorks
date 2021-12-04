using System;
using System.Collections.Generic;
using System.Text;

namespace MyMediator
{
    class FirstUser : User
    {
        public FirstUser(MessengerMediator messenger, string username) : base(messenger, username) { }
    }
}
