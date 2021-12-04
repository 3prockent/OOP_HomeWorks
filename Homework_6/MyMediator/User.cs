using System;
using System.Collections.Generic;
using System.Text;

namespace MyMediator
{
    abstract class User
    {
        public MessengerMediator Messenger { get; private set; }
        public string Name { get; private set; }
        public User(MessengerMediator messenger, string username)
        {
            Messenger = messenger;
            Name = username;
        }
        public void Send(string message)
        {
            Messenger.Send(message, this);
        }
        public void Notify(string receivedMes)
        {
            Console.WriteLine(Name + " received message: " + receivedMes);
        }
    }
}
