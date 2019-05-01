using System.Reflection.Metadata.Ecma335;

namespace pokusT {
    public class AccessControl {
        private int cardId;
        private  static int passCount;
        private int roomId;
        private User user;

        public int CardId {
            get => cardId;
            set => cardId = value;
        }

        public static int PassCount {
            get => passCount;
            set => passCount = passCount+1;
        }

        public int RoomId {
            get => roomId;
            set => roomId = value;
        }

        public User User {
            get => user;
            set => user = value;
        }


        public Access PassControl(Card c, int roomId) {
            PassCount++;
            if (c.CardId == this.CardId && roomId == this.RoomId) {
                return Access.Pass;
            }

            return Access.Fail;
        }
    }
}