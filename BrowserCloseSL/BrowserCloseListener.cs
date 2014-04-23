using System;
using System.Windows;
using System.Windows.Browser;

namespace BrowserCloseSL
{
    public class BrowserCloseListener : IBrowserCloseListener
    {
        public const string ScriptableObjectName = "BrowserCloseSL";

        public event EventHandler<BeforeCloseEventArgs> BeforeClose;

        [ScriptableMember]
        public bool IsEnabled { get; set; }

        public BrowserCloseListener()
        {
            HtmlPage.RegisterScriptableObject(ScriptableObjectName, this);

            var pluginName = HtmlPage.Plugin.Id;
            var script = string.Format(
                @"window.onbeforeunload = function () {{
                    var slApp = document.getElementById('{0}');
                    var isListening = slApp.Content.{1}.IsEnabled;
                    if (!isListening) {{
                        return;
                    }}

                    var result = slApp.Content.{1}.OnBeforeUnload();
                    if(!result.CanClose) {{
                        return result.Confirmation;
                    }}
                }}; ", pluginName, ScriptableObjectName);

            HtmlPage.Window.Eval(script);

            IsEnabled = true;
        }

        [ScriptableMember]
        public BeforeCloseEventArgs OnBeforeUnload()
        {
            var args = new BeforeCloseEventArgs { CanClose = true };
            var handler = BeforeClose;
            if (handler != null)
            {
                handler(Application.Current, args);
            }

            if (!args.CanClose && string.IsNullOrEmpty(args.Confirmation))
            {
                args.Confirmation = "Do you want to leave?";
            }
            
            return args;
        }
    }
}
