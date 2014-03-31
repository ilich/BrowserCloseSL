using System;
using System.Windows.Browser;

namespace BrowserCloseSL
{
    public class BeforeCloseEventArgs : EventArgs
    {
        [ScriptableMember]
        public string Confirmation { get; set; }

        [ScriptableMember]
        public bool CanClose { get; set; }
    }
}
