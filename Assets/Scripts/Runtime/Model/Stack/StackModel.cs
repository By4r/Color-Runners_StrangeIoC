using Runtime.Data.UnityObject;
using UnityEngine;

namespace Runtime.Model.Stack
{
    public class StackModel : IStackModel
    {
        private CD_Stack _stackData;

        private const string StackDataPath = "Data/CD_Stack"; // Fixed the syntax error here

        [PostConstruct]
        private void OnLoadStackData()
        {
            _stackData = Resources.Load<CD_Stack>(StackDataPath);
        }

        public CD_Stack StackData // Fixed the property name to match the field type
        {
            get
            {
                if (_stackData == null)
                {
                    OnLoadStackData();
                }

                return _stackData;
            }
            set => _stackData = value;
        }
    }
}