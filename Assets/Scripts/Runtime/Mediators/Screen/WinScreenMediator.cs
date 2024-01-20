using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Rich.Base.Runtime.Signals;
using Runtime.Signals;
using Runtime.Views.Screen;

namespace Runtime.Mediators.Screen
{
    public class WinScreenMediator : MediatorLite
    {
        [Inject] public WinScreenView View { get; set; }
        [Inject] public LevelSignals LevelSignals { get; set; }
        [Inject] public CoreGameSignals CoreGameSignals { get; set; }
        [Inject] public CoreScreenSignals CoreScreenSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.onNextLevel += OnNextLevel;
        }


        private void OnNextLevel()
        {
            LevelSignals.onNextLevel?.Dispatch();
            CoreGameSignals.onReset?.Dispatch();
            CoreScreenSignals.ClearLayerPanel?.Dispatch(2);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.onNextLevel -= OnNextLevel;
        }
    }
}