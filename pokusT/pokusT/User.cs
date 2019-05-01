using System;
using System.Runtime.CompilerServices;

namespace pokusT {
    public class User {
        private string firstName;
        private string lastName;

        public User(string firstName, string lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName {
            get => firstName;
            set => firstName = value;
        }

        public string LastName {
            get => lastName;
            set => lastName = value;
        }
    }
}