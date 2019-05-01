using System;

namespace test2 {
    public class NotEnoughMoneyExeption:Exception {
        public NotEnoughMoneyExeption(double money) {
            Console.WriteLine("nedostatek penez, na konte je " + money);
        }
    }
}