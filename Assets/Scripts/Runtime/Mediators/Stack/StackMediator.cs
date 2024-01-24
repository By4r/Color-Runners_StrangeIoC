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
            //StackSignals.onInteractionCollectable.AddListener(StackView.OnInteractionCollectable);

            //StackView.OnInteractionCollectable += OnInteractionCollectable;
            StackView.onInteractCollect += OnInteractCollect;

        }



        
        /*private void OnInteractionCollectable(GameObject obj)
        {
            Debug.Log("ON INTERACTION COLLECTABLE WORKED !");
            Debug.Log("Other Object" +obj);
            AddStack(obj);
        }
        
        private void AddStack(GameObject collectableGameObject)
        {
            if (StackView._collectableStack.Count <= 0)
            {
                StackView._collectableStack.Add(collectableGameObject);
                //_collectableStack.Add(collectableGameObject);
                //_collectableManager.CollectableAnimRun();
                collectableGameObject.transform.SetParent(StackView.transform);
                collectableGameObject.transform.localPosition = new Vector3(0, 1f, 0.335f); // y: 1f
            }
            else
            {
                collectableGameObject.transform.SetParent(StackView.transform);
                Vector3 newPos = StackView._collectableStack[^1].transform.localPosition;
                newPos.z += StackView._data.CollectableOffsetInStack;
                collectableGameObject.transform.localPosition = newPos;
                StackView._collectableStack.Add(collectableGameObject);
                //_collectableManager.CollectableAnimRun();

            }
        }*/
        

        public override void OnRemove()
        {
            base.OnRemove();
            //StackSignals.onInteractionCollectable.RemoveListener(StackView.OnInteractionCollectable);

            //StackView.OnInteractionCollectable -= OnInteractionCollectable;
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