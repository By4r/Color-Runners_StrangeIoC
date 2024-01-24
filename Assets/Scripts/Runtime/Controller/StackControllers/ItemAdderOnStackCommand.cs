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
    }
}