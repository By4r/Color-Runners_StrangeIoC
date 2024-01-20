using Cinemachine;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Views.Player;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Views.Camera
{
    public class CameraView : RichView
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        #endregion

        #region Private Variables

        private Vector3 _firstPosition;

        #endregion

        #endregion

        protected override void Start()
        {
            base.Start();
            Init();
        }

        private void Init()
        {
            _firstPosition = transform.position;
        }

        public void AssignCameraTarget()
        {
            var player = FindObjectOfType<PlayerView>();
            virtualCamera.Follow = player.transform;
        }

        public void OnReset()
        {
            transform.position = _firstPosition;
        }
    }
}