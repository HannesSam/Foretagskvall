using System;
using System.Collections.Generic;
using System.Text;

namespace Foretagskvall_prototyp
{
    class User
    {
        public string Email { get; private set; }
        public int[] Picks { get; private set; }
        public User(string email, int[] picks)
        {
            Email = email;
            Picks = picks;
        }
    }
}
