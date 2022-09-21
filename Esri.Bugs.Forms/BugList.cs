using System;
using System.Collections;
using System.Collections.Generic;

namespace Esri.Bugs.Forms
{
    public class BugList : List<BugInfo>
    {
        public BugList()
        {
            Add(new BugInfo("Back & Freeze Bug", typeof(FreezeDemo)));
        }
    }

    public class BugInfo
    {
        public BugInfo(string name, Type demoPageType)
        {
            Name = name;
            DemoPageType = demoPageType;
        }

        public string Name { get; set; }
        public Type DemoPageType { get; set; }
    }
}