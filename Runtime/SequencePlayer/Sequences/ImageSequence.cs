using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Kuroneko.UIDelivery
{
    [Serializable]
    public class ImageSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public Image sequencer;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public ImageSequenceType type;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", ImageSequenceType.DOColor)]
        public Color color;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", ImageSequenceType.DOFade)]
        public float fade = 0f;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", ImageSequenceType.DOFillAmount)]
        public float fillAmount = 0f;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", ImageSequenceType.DOGradientColor)]
        public Gradient gradient;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", ImageSequenceType.DOGradientColor)]
        public Color blendColor;

        public override Tween ToTween()
        {
            return type switch
            {
                ImageSequenceType.DOColor => sequencer.DOColor(color, duration).SetEase(easing),
                ImageSequenceType.DOFade => sequencer.DOFade(fade, duration).SetEase(easing),
                ImageSequenceType.DOFillAmount => sequencer.DOFillAmount(fillAmount, duration).SetEase(easing),
                ImageSequenceType.DOGradientColor => sequencer.DOGradientColor(gradient, duration).SetEase(easing),
                ImageSequenceType.DOBlendableColor => sequencer.DOBlendableColor(blendColor, duration).SetEase(easing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}