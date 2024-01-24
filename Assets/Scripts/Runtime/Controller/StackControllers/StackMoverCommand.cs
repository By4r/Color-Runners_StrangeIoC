using System.Collections.Generic;
using Runtime.Signals;
using Runtime.Data.ValueObject;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller.StackControllers
{
    public class StackMoverCommand : Command
    {
        
        [Inject] private StackSignals StackSignals { get; set; }

        public override void Execute()
        {
            
        }
        
    }
}