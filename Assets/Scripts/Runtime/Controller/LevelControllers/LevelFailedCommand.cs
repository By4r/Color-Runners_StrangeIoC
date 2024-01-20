using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller.LevelControllers
{
    public class LevelFailedCommand : Command
    {
        [Inject] public LevelSignals LevelSignals { get; set; }
        [Inject] public CoreGameSignals CoreGameSignals { get; set; }

        public override void Execute()
        {
            LevelSignals.onDestroyLevel?.Dispatch();
            CoreGameSignals.onReset?.Dispatch();
            LevelSignals.onInitializeLevel?.Dispatch();
        }
    }
}