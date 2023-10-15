using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class RectTransformSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public RectTransform sequencer;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public RectTransformSequenceType type;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOScale)]
        public Vector3 scale;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOScaleX)]
        public float scaleX;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOScaleY)]
        public float scaleY;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOScaleZ)]
        public float scaleZ;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOMove)]
        public Vector3 move;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOMoveX)]
        public float moveX;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOMoveY)]
        public float moveY;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOMoveZ)]
        public float moveZ;

        public override Tween ToTween()
        {
            return type switch
            {
                RectTransformSequenceType.DOScale => sequencer.DOScale(scale, duration).SetEase(easing),
                RectTransformSequenceType.DOScaleX => sequencer.DOScaleX(scaleX, duration).SetEase(easing),
                RectTransformSequenceType.DOScaleY => sequencer.DOScaleY(scaleY, duration).SetEase(easing),
                RectTransformSequenceType.DOScaleZ => sequencer.DOScaleZ(scaleZ, duration).SetEase(easing),
                RectTransformSequenceType.DOMove => sequencer.DOMove(move, duration).SetEase(easing),
                RectTransformSequenceType.DOMoveX => sequencer.DOMoveX(moveX, duration).SetEase(easing),
                RectTransformSequenceType.DOMoveY => sequencer.DOMoveY(moveY, duration).SetEase(easing),
                RectTransformSequenceType.DOMoveZ => sequencer.DOMoveZ(moveZ, duration).SetEase(easing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}