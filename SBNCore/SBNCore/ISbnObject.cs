using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sbn.Core
{

    public interface ISbnObject
    {
        void Save(string PhysicalPath);
        void SaveToSingleFile(string PhysicalPath);
        void Load(string PhysicalPath, List<string> CustomAttributes);
        string GetXML(string sNodeName);
        void Initialize();

    }
}
