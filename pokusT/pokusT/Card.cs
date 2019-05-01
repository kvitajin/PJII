
using System;

namespace pokusT {
    public class Card {
        private int cardId;
        private string holderFirstName;
        private string holderLastName;

        public int CardId {
            get => cardId;
            set => cardId = value;
        }

        public string HolderFirstName {
            get => holderFirstName;
            set => holderFirstName = value;
        }

        public string HolderLastName {
            get => holderLastName;
            set => holderLastName = value;
        }

        public Card(string tmp) {
            string[] jmena = tmp.Split("-");
            Int32.TryParse(jmena[0], out cardId);
            jmena = jmena[1].Split("/");
            HolderFirstName = jmena[0];
            HolderLastName = jmena[1];
        }
    }
}