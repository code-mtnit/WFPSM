using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionPresent.Tools
{
    public interface ISessionUser
    {

        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string AliasCode { get; set; }

        

    }
}
