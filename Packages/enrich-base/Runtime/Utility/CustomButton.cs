using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rich.Base.Runtime.Utility
{
    public class CustomButton : MonoBehaviour,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerExitHandler,
        IDragHandler,
        IBeginDragHandler,
        IEndDragHandler,
        IPointerClickHandler
    {
        public ScrollRect Scroll;

        public UnityEvent onPress = new UnityEvent();
        public UnityEvent onLongPress = new UnityEvent();

        // settings
        private float holdTime = 0.45f;
        private float detectGesturePixelThreshold = 15;

        // members
        private bool longPressDetected;
        private float cumulativeYDelta = 0;

        // object links
        private IDragHandler scrollviewParentIDragHandler;
        private IBeginDragHandler scrollviewParentIBeginDragHandler;
        private IEndDragHandler scrollviewParentIEndDragHandler;


        private void Start()
        {
            Setup();
        }

        public void Setup()
        {
            if (Scroll == null)
                Scroll = GetComponentInParent<ScrollRect>();

            scrollviewParentIDragHandler = Scroll;
            scrollviewParentIBeginDragHandler = Scroll;
            scrollviewParentIEndDragHandler = Scroll;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            longPressDetected = false;
            Invoke("OnLongPress", holdTime);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (longPressDetected || eventData.dragging)
                return;

            CancelInvoke("OnLongPress");

            //if (SelectionManager.Instance.HasSelection())
            //    onLongPress.Invoke();
            //else
            onPress.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CancelInvoke("OnLongPress");
        }

        void OnLongPress()
        {
            longPressDetected = true;
            onLongPress.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            cumulativeYDelta += eventData.delta.y;

            if (Mathf.Abs(cumulativeYDelta) > detectGesturePixelThreshold)
                CancelInvoke("OnLongPress");

            scrollviewParentIDragHandler.OnDrag(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            cumulativeYDelta = 0;
            scrollviewParentIBeginDragHandler.OnBeginDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            scrollviewParentIEndDragHandler.OnEndDrag(eventData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (longPressDetected)
                eventData.Use();
        }
    }
}