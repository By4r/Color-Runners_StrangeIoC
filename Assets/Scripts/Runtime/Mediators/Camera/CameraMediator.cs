using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Signals;
using Runtime.Views.Camera;


namespace Runtime.Mediators.Camera
{
    public class CameraMediator : MediatorLite
    {
        [Inject] public CameraView View { get; set; }
        [Inject] public CameraSignals CameraSignals { get; set; }
        [Inject] public CoreGameSignals CoreGameSignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();

            CameraSignals.onSetCameraTarget.AddListener(OnSetCameraTarget);
            CoreGameSignals.onReset.AddListener(View.OnReset);
        }

        private void OnSetCameraTarget()
        {
            View.AssignCameraTarget();
        }

        public override void OnRemove()
        {
            base.OnRemove();

            CameraSignals.onSetCameraTarget.RemoveListener(OnSetCameraTarget);
            CoreGameSignals.onReset.RemoveListener(View.OnReset);
        }
    }
}