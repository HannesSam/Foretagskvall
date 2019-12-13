using System;
using System.Collections.Generic;
using System.Text;

namespace Foretagskvall_prototyp
{
    class Allocation
    {
        public string[] Company1 { get; private set; }
        public string[] Company2 { get; private set; }
        public string[] Company3 { get; private set; }
        public string[] Company4 { get; private set; }

        private User[] Users;
        public Allocation(User[] users)
        {
            Users = users;
        }
    }
}
