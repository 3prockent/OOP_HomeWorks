using System;
using System.Collections.Generic;
using System.Text;

namespace MyMediator
{
    abstract class MessengerMediator
    {
        public abstract void Send(string message, User sender);
    }
}
