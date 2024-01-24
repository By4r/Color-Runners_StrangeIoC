using System.Collections.Generic;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Data.ValueObject;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Views.Stack
{
    public class StackView : RichView
    {
        #region Public Variables

        //public UnityAction<GameObject> OnInteractionCollectable = delegate { };
        public UnityAction onInteractCollect = delegate { };

        #endregion
        
        #region Serialized Variables

        [SerializeField] internal GameObject collectableStickMan;

        #endregion

        #region Private Variables

        internal StackData _data;
        internal List<GameObject> _collectableStack = new List<GameObject>();

        [Inject] public StackSignals StackSignals { get; set; }
        
        //private readonly string _stackDataPath = "Data/CD_Stack";

        #endregion
        
        public void SetStackData(StackData stackData)
        {
            _data = stackData;
        }
        
        /*internal void OnInteractionCollectable(GameObject obj)
        {
            Debug.Log("ON INTERACTION COLLECTABLE WORKED !");
            //Debug.Log("Other Object" +obj);
            AddStack(obj);
        }
        
        private void AddStack(GameObject collectableGameObject)
        {
            if (_collectableStack.Count <= 0)
            {
                _collectableStack.Add(collectableGameObject);
                //_collectableStack.Add(collectableGameObject);
                //_collectableManager.CollectableAnimRun();
                collectableGameObject.transform.SetParent(this.transform);
                collectableGameObject.transform.localPosition = new Vector3(0, 1f, 0.335f); // y: 1f
            }
            else
            {
                collectableGameObject.transform.SetParent(this.transform);
                Vector3 newPos = _collectableStack[^1].transform.localPosition;
                newPos.z += _data.CollectableOffsetInStack;
                collectableGameObject.transform.localPosition = newPos;
                _collectableStack.Add(collectableGameObject);
                //_collectableManager.CollectableAnimRun();

            }
        }*/
        
    }
}