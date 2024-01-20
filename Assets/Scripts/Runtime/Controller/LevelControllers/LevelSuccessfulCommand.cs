using Runtime.Model;
using Runtime.Model.Level;
using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller.LevelControllers
{
    public class LevelSuccessfulCommand : Command
    {
        [Inject] public ILevelModel LevelModel { get; set; }
        [Inject] public LevelSignals LevelSignals { get; set; }
        [Inject] public CoreGameSignals CoreGameSignals { get; set; }

        public override void Execute()
        {
            LevelModel.IncrementLevel();
            LevelSignals.onDestroyLevel?.Dispatch();
            CoreGameSignals.onReset?.Dispatch();
            LevelSignals.onInitializeLevel?.Dispatch();
        }
    }
}