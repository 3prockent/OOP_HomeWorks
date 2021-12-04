using System;

namespace MyMediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger messenger = new Messenger();
            FirstUser user1 = new FirstUser(messenger, "Julia");
            SecondUser user2 = new SecondUser(messenger, "Sonya");
            ThirdUser user3 = new ThirdUser(messenger, "John");
            messenger.User1 = user1;
            messenger.User2 = user2;
            messenger.User3 = user3;

            messenger.Send("Hello!", user3);
            messenger.Send("How are you?", user1);
            messenger.Send("Fine, thanks", user2);
            Console.ReadLine();
        }
    }
}
