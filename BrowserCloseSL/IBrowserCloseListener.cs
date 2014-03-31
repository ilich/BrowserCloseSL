using System;

namespace BrowserCloseSL
{
    public interface IBrowserCloseListener
    {
        event EventHandler<BeforeCloseEventArgs> BeforeClose;

        bool IsEnabled { get; set; }
    }
}
