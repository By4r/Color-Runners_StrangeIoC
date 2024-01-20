using System.Collections.Generic;
using DG.Tweening;
using Rich.Base.Runtime.Abstract.View;
using Runtime.Data.ValueObject;
using Sirenix.OdinInspector;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Views.Pool
{
    public class PoolControllerView : RichView
    {
        public byte StageValue;


        [SerializeField] private List<DOTweenAnimation> tweens = new List<DOTweenAnimation>();
        [SerializeField] private TextMeshPro poolText;
        [SerializeField] private new Renderer renderer;
        [SerializeField] private float3 poolAfterColor = new float3(0.1607843f, 0.3144797f, 0.6039216f);

        [ShowInInspector] private PoolData _data;
        [ShowInInspector] private byte _collectedCount;

        private readonly string _collectable = "Collectable";


        public bool OnGetPoolResult(byte managerStageValue)
        {
            if (StageValue != managerStageValue) return false;
            return _collectedCount >= _data.RequiredObjectCount;
        }

        public void SetPoolData(PoolData poolData)
        {
            _data = poolData;
        }

        public void OnActivateTweens(byte stageValue)
        {
            if (stageValue != StageValue) return;
            foreach (var tween in tweens)
            {
                tween.DOPlay();
            }
        }

        public void OnChangePoolColor(byte stageValue)
        {
            if (stageValue != StageValue) return;
            renderer.material.DOColor(new Color(poolAfterColor.x, poolAfterColor.y, poolAfterColor.z, 1), .5f)
                .SetEase(Ease.Flash)
                .SetRelative(false);
        }

        protected override void Start()
        {
            base.Start();
            SetRequiredAmountText();
        }

        private void SetRequiredAmountText()
        {
            poolText.text = $"0/{_data.RequiredObjectCount}";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_collectable)) return;
            IncreaseCollectedAmount();
            SetCollectedAmountToPool();
        }

        private void IncreaseCollectedAmount()
        {
            _collectedCount++;
        }

        private void SetCollectedAmountToPool()
        {
            poolText.text = $"{_collectedCount}/{_data.RequiredObjectCount}";
        }

        private void DecreaseCollectedAmount()
        {
            _collectedCount--;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(_collectable)) return;
            DecreaseCollectedAmount();
            SetCollectedAmountToPool();
        }
    }
}