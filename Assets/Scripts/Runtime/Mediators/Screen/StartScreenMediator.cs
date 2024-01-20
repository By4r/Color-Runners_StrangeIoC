using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Rich.Base.Runtime.Signals;
using Runtime.Signals;
using Runtime.Views.Screen;

namespace Runtime.Mediators.Screen
{
    public class StartScreenMediator : MediatorLite
    {
        [Inject] public StartScreenView View { get; set; }
        [Inject] public UISignals UISignals { get; set; }
        [Inject] public CameraSignals CameraSignals { get; set; }
        [Inject] public CoreScreenSignals CoreScreenSignals { get; set; }
        [Inject] public InputSignals InputSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.onPlay += OnPlay;
        }

        private void OnPlay()
        {
            UISignals.onPlay.Dispatch();
            CameraSignals.onSetCameraTarget.Dispatch();
            CoreScreenSignals.ClearLayerPanel.Dispatch(0);
            InputSignals.onEnableInput?.Dispatch();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.onPlay -= OnPlay;
        }
    }
}