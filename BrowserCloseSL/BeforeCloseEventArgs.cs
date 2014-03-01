using System;

namespace BrowserCloseSL
{
    public class BeforeCloseEventArgs : EventArgs
    {
        public string Confirmation { get; set; }

        public bool CanClose { get; set; }
    }
}
