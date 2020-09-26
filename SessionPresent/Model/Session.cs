using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionPresent.Model
{
    public class Session
    {

        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan SessionTime { get; set; }
    }
}
