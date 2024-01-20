using Runtime.Model.Player;
using Runtime.Signals;
using strange.extensions.command.impl;

namespace Runtime.Controller.PlayerControllers
{
    public class OnStageAreaSuccessfulCommand : Command
    {
        [Inject] public UISignals UISignals { get; set; }
        [Inject] public IPlayerModel PlayerModel { get; set; }

        public override void Execute()
        {
            UISignals.onSetStageColor.Dispatch(PlayerModel.StageValue);
        }
    }
}