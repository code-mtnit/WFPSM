using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionPresent.Model
{
    public class SessionUser
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string AliasCode { get; set; }

        public string Password { get; set; }


        public string Description { get; set; }
    }
}
