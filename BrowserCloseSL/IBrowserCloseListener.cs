﻿using System;

namespace BrowserCloseSL
{
    public interface IBrowserCloseListener
    {
        event EventHandler<BeforeCloseEventArgs> BeforeClose;

        void Start();

        void Stop();
    }
}
