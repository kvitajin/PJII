using System;

namespace pokusT {
    class Program {
        static void Main(string[] args) {
            Card card = new Card("123456789-Edie/Amoulen");
            Console.WriteLine(card.CardId + " " + card.HolderLastName + " " + card.HolderFirstName);
        }
    }
}