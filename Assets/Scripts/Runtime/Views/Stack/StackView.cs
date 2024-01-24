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
        [SerializeField] internal int numberOfCollectablesToSpawn = 10;

        #endregion

        #region Private Variables

        internal StackData _data;
        internal List<GameObject> _collectableStack = new List<GameObject>();
        private List<GameObject> _inactiveCollectables = new List<GameObject>();

        [Inject] public StackSignals StackSignals { get; set; }
        
        //private readonly string _stackDataPath = "Data/CD_Stack";

        #endregion

        protected override void Start()
        {
            base.Start();
            PrepareCollectableStickMen(numberOfCollectablesToSpawn);
        }

        public void SetStackData(StackData stackData)
        {
            _data = stackData;
        }
        private void PrepareCollectableStickMen(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject collectable = Instantiate(collectableStickMan, this.transform);
                collectable.SetActive(false);
                _inactiveCollectables.Add(collectable); // Add the spawned object to the list
            }
        }
        
        // Method to be called when the collectable is interacted with.
        internal void OnInteractionCollectable()
        {
            Debug.Log("ON INTERACTION COLLECTABLE WORKED !");

            if (_inactiveCollectables.Count > 0)
            {
                GameObject inactiveCollectable = _inactiveCollectables[0];
                _inactiveCollectables.RemoveAt(0); // Remove the object from the list

                AddStack(inactiveCollectable);
            }
            else
            {
                Debug.LogWarning("No inactive collectables available.");
            }
        }
        
        private void AddStack(GameObject collectableGameObject)
        {
            if (_collectableStack.Count <= 0)
            {
                _collectableStack.Add(collectableGameObject);
                collectableGameObject.transform.SetParent(this.transform);
                collectableGameObject.transform.localPosition = new Vector3(0, 1f, 0.335f);
                collectableGameObject.SetActive(true);
            }
            else
            {
                collectableGameObject.transform.SetParent(this.transform);
                Vector3 newPos = _collectableStack[_collectableStack.Count - 1].transform.localPosition;
                newPos.z += 1.0f; // Change this to your desired offset
                collectableGameObject.transform.localPosition = newPos;
                _collectableStack.Add(collectableGameObject);
                collectableGameObject.SetActive(true);
            }
        }
        
    }
}