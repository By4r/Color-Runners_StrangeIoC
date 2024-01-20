using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Key;
using Runtime.Model.Input;
using Runtime.Signals;
using Runtime.Views.Input;

namespace Runtime.Mediators.Input
{
    public class InputMediator : MediatorLite
    {
        [Inject] public InputSignals InputSignals { get; set; }
        [Inject] public IInputModel InputModel { get; set; }
        [Inject] public InputView InputView { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            InputView.onInputTaken += OnInputTaken;
            InputView.onInputReleased += OnInputReleased;
            InputView.onInputDragged += OnInputDragged;
            InputView.onFirstTimeTouchTaken += OnFirstTimeTouchTaken;

            InputSignals.onEnableInput.AddListener(InputView.EnableInput);
            InputSignals.onDisableInput.AddListener(InputView.DisableInput);
        }

        private void OnFirstTimeTouchTaken()
        {
            InputSignals.onFirstTimeTouchTaken.Dispatch();
        }

        private void OnInputDragged(HorizontalInputParams inputParams)
        {
            InputSignals.onInputDragged.Dispatch(inputParams);
        }

        private void OnInputReleased()
        {
            InputSignals.onInputReleased.Dispatch();
        }

        private void OnInputTaken()
        {
            InputSignals.onInputTaken.Dispatch();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            InputView.onInputTaken -= OnInputTaken;
            InputView.onInputReleased -= OnInputReleased;
            InputView.onInputDragged -= OnInputDragged;
            InputView.onFirstTimeTouchTaken -= OnFirstTimeTouchTaken;

            InputSignals.onEnableInput.RemoveListener(InputView.EnableInput);
            InputSignals.onDisableInput.RemoveListener(InputView.DisableInput);
        }

        public override void OnEnabled()
        {
            InputView.SetInputData(InputModel.InputData.Data);
        }
    }
}