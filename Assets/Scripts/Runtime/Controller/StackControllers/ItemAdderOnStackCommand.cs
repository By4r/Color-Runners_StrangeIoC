using Runtime.Data.ValueObject;
using Runtime.Signals;
using Runtime.Views.Stack;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller.StackControllers
{
    public class ItemAdderOnStackCommand : Command
    {
        [Inject] private StackSignals StackSignals { get; set; }
        
        public override void Execute()
        {
            StackSignals.onInteractionCollectable.Dispatch();
        }
        
        
        // public ItemAdderOnStackCommand(StackManager stackManager,CollectableManager collectableManager, ref List<GameObject> collectableStack,
        //     ref StackData stackData)
        // {
        //     _stackManager = stackManager;
        //     _collectableManager = collectableManager;
        //     _collectableStack = collectableStack;
        //     _data = stackData;
        // }
        

        /*public void Execute(GameObject collectableGameObject)
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
                newPos.z += _data.CollectableOffsetInStack;
                collectableGameObject.transform.localPosition = newPos;
                StackView._collectableStack.Add(collectableGameObject);
                //_collectableManager.CollectableAnimRun();

            }
        }*/
    }
}