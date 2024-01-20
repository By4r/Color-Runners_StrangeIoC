using Rich.Base.Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OpenStartScreenPanelCommand : Command
    {
        [Inject] public CoreScreenSignals CoreScreenSignals { get; set; }

        public override void Execute()
        {
            CoreScreenSignals.OpenPanel.Dispatch(new OpenNormalPanelArgs()
            {
                IgnoreHistory = false,
                LayerIndex = 0,
                PanelKey = "StartScreen"
            });
        }
    }
}