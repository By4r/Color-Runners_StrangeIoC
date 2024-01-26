using Cinemachine;
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
        

        public override void OnRegister()
        {
            base.OnRegister();
            StackSignals.onStackFollowPlayer.AddListener(StackView.OnStackMove);
            StackSignals.onStackCollectable.AddListener(StackView.OnStackCollectable);
            StackSignals.onInteractionObstacle.AddListener(StackView.OnInteractObstacle);

            StackView.onInteractCollect += OnInteractCollect;
        }


        public override void OnRemove()
        {
            base.OnRemove();

            StackSignals.onStackFollowPlayer.RemoveListener(StackView.OnStackMove);
            StackSignals.onStackCollectable.RemoveListener(StackView.OnStackCollectable);
            StackSignals.onInteractionObstacle.RemoveListener(StackView.OnInteractObstacle);

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