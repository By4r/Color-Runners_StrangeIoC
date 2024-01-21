using System.Collections.Generic;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Views.Stack
{
    public class StackView : RichView
    {
        #region Serialized Variables

        [SerializeField] private GameObject collectableStickMan;

        #endregion

        #region Private Variables

        private StackData _data;
        private List<GameObject> _collectableStack = new List<GameObject>();

        //private readonly string _stackDataPath = "Data/CD_Stack";

        #endregion
        
        public void SetStackData(StackData stackData)
        {
            _data = stackData;
        }
    }
}