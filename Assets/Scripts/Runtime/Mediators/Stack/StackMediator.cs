using DG.Tweening;
using Rich.Base.Runtime.Concrete.Injectable.Mediator;
using Runtime.Model.Player;
using Runtime.Model.Stack;
using Runtime.Signals;
using Runtime.Views.Player;
using Runtime.Views.Pool;
using Runtime.Views.Stack;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Runtime.Mediators.Stack
{
    public class StackMediator : MediatorLite
    {
        
        [Inject] public StackView StackView { get; set; }
        
        [Inject] public IStackModel model { get; set; }
        
        [Inject] public StackSignals StackSignals { get; set; }
        
        //[Inject] public PlayerView View { get; set; }
        // [Inject] public IPlayerModel Model { get; set; }
        // [Inject] public InputSignals InputSignals { get; set; }
        // [Inject] public PlayerSignals PlayerSignals { get; set; }
        // [Inject] public CoreGameSignals CoreGameSignals { get; set; }

        //[Inject] public UISignals UISignals { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            StackSignals.onStackFollowPlayer.AddListener(StackView.OnStackMove);
            StackSignals.onInteractionCollectable.AddListener(StackView.OnInteractionCollectable);

            StackView.onInteractCollect += OnInteractCollect;

        }
        

        public override void OnRemove()
        {
            base.OnRemove();
            StackSignals.onInteractionCollectable.RemoveListener(StackView.OnInteractionCollectable);
            StackSignals.onStackFollowPlayer.RemoveListener(StackView.OnStackMove);

            StackView.onInteractCollect -= OnInteractCollect;

        }

        private void OnInteractCollect()
        {
            Debug.LogWarning("ON INTERACT COLLECT WORK !");
        }

        public override void OnEnabled()
        {
            base.OnEnabled();
            StackView.SetStackData(model.StackData.Data);
        }
    }
}