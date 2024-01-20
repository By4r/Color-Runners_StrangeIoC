using Rich.Base.Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller
{
    public class OpenLevelSuccessfulScreenCommand : Command
    {
        [Inject] public CoreScreenSignals CoreScreenSignals { get; set; }

        public override void Execute()
        {
            CoreScreenSignals.OpenPanel.Dispatch(new OpenNormalPanelArgs()
            {
                IgnoreHistory = false,
                LayerIndex = 2,
                PanelKey = "WinScreen"
            });
        }
    }
}