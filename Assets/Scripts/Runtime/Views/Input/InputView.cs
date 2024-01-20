using System.Collections.Generic;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Data.ValueObject;
using Runtime.Key;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Runtime.Views.Input
{
    public class InputView : RichView
    {
        public UnityAction onInputTaken;
        public UnityAction onInputReleased;
        public UnityAction<HorizontalInputParams> onInputDragged;
        public UnityAction onFirstTimeTouchTaken;

        private InputData _data;

        private bool _isInputEnabled;

        [ShowInInspector] private bool _isFirstTimeTouchTaken, _isTouching;

        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;

        public void SetInputData(InputData inputData)
        {
            _data = inputData;
        }

        public void EnableInput()
        {
            _isInputEnabled = true;
        }

        public void DisableInput()
        {
            _isInputEnabled = false;
        }

        private void Update()
        {
            if (!_isInputEnabled) return;

            if (UnityEngine.Input.GetMouseButtonUp(0) && !IsPointerOverUIElement())
            {
                _isTouching = false;
                onInputReleased?.Invoke();
            }

            if (UnityEngine.Input.GetMouseButtonDown(0) && !IsPointerOverUIElement())
            {
                _isTouching = true;
                onInputTaken?.Invoke();
                if (!_isFirstTimeTouchTaken)
                {
                    _isFirstTimeTouchTaken = true;
                    onFirstTimeTouchTaken?.Invoke();
                }

                _mousePosition = UnityEngine.Input.mousePosition;
            }

            if (UnityEngine.Input.GetMouseButton(0) && !IsPointerOverUIElement())
            {
                if (_isTouching)
                {
                    if (_mousePosition != null)
                    {
                        var mouseDeltaPos = (Vector2)UnityEngine.Input.mousePosition - _mousePosition.Value;
                        if (mouseDeltaPos.x > _data.HorizontalInputSpeed)
                            _moveVector.x = _data.HorizontalInputSpeed / 10f * mouseDeltaPos.x;
                        else if (mouseDeltaPos.x < -_data.HorizontalInputSpeed)
                            _moveVector.x = -_data.HorizontalInputSpeed / 10f * -mouseDeltaPos.x;
                        else
                            _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                                _data.ClampSpeed);

                        _moveVector.x = mouseDeltaPos.x;

                        _mousePosition = UnityEngine.Input.mousePosition;

                        onInputDragged?.Invoke(new HorizontalInputParams()
                        {
                            HorizontalValue = _moveVector.x,
                            ClampValues = _data.ClampPosition
                        });
                    }
                }
            }
        }

        private bool IsPointerOverUIElement()
        {
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = UnityEngine.Input.mousePosition
            };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }

        public void OnReset()
        {
            _isInputEnabled = false;
            //_isFirstTimeTouchTaken = false;
            _isTouching = false;
        }
    }
}