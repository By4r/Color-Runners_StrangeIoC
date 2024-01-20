using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Signals;
using Runtime.Views.Screen;

namespace Runtime.Mediators.Screen
{
    public class LevelScreenMediator : MediatorLite
    {
        [Inject] public UISignals UISignals { get; set; }
        [Inject] public LevelScreenView View { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            UISignals.onSetStageColor.AddListener(View.OnSetStageColor);
            UISignals.onSetNewLevelValue.AddListener(View.OnSetLevelValue);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            UISignals.onSetStageColor.RemoveListener(View.OnSetStageColor);
            UISignals.onSetNewLevelValue.RemoveListener(View.OnSetLevelValue);
        }
    }
}