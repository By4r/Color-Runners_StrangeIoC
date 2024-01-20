using Runtime.Model;
using Runtime.Model.Level;
using strange.extensions.command.impl;
using UnityEngine;

namespace Runtime.Controller
{
    public class DestroyLevelCommand : Command
    {
        [Inject] ILevelModel LevelModel { get; set; }

        public override void Execute()
        {
            if (LevelModel.LevelHolder.transform.childCount <= 0) return;
            Object.Destroy(LevelModel.LevelHolder.transform.GetChild(0).gameObject);
        }
    }
}