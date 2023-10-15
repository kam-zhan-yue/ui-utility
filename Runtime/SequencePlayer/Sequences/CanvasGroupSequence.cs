using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class CanvasGroupSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public CanvasGroupSequenceType type = CanvasGroupSequenceType.DOFade;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public CanvasGroup sequencer;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", CanvasGroupSequenceType.DOFade)]
        public float fade;


        public override Tween ToTween()
        {
            return type switch
            {
                CanvasGroupSequenceType.DOFade => sequencer.DOFade(fade, duration).SetEase(easing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}