using System.Collections.Generic;
using DG.Tweening;
using Rich.Base.Runtime.Abstract.Data.ValueObject;
using Rich.Base.Runtime.Abstract.Function;
using Rich.Base.Runtime.Abstract.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Views.Screen
{
    public class LevelScreenView : RichView, IPanel
    {
        [SerializeField] private List<Image> stageImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();

        public IPanelVo vo { get; set; }

        //We want this to be initialized by RichScreenManager
        public override bool autoRegisterWithContext
        {
            get => false;
        }

        public void OnSetStageColor(byte stageValue)
        {
            stageImages[stageValue].DOColor(new Color(0.9960785f, 0.4196079f, 0.07843138f), 0.5f);
        }

        public void OnSetLevelValue(byte levelValue)
        {
            var additionalValue = ++levelValue;
            levelTexts[0].text = additionalValue.ToString();
            additionalValue++;
            levelTexts[1].text = additionalValue.ToString();
        }
    }
}