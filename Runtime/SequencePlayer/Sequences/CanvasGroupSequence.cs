using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class CanvasGroupSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public CanvasGroup sequencer;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public CanvasGroupSequenceType type;

        public override Tween ToTween()
        {
            throw new NotImplementedException();
        }
    }
}