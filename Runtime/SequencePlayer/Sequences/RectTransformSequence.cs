using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIDelivery
{
    [Serializable]
    public class RectTransformSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public RectTransformSequenceType type;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public RectTransform sequencer;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOAnchorMax)]
        public Vector2 anchorMax;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOAnchorMin)]
        public Vector2 anchorMin;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOAnchorPos)]
        public Vector2 anchorPos;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOAnchorPos3D)]
        public Vector3 anchorPos3D;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOPivot)]
        public Vector2 pivot;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOPunchAnchorPos)]
        public Vector2 punch;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOShakeAnchorPos)]
        public Vector3 shake;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOSizeDelta)]
        public Vector2 size;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOShapeCircle)]
        public Vector3 center;
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", RectTransformSequenceType.DOShapeCircle)]
        public float endValueDegrees;

        public override Tween ToTween()
        {
            return type switch
            {
                RectTransformSequenceType.DOAnchorMax => sequencer.DOAnchorMax(anchorMax, duration).SetEase(easing),
                RectTransformSequenceType.DOAnchorMin => sequencer.DOAnchorMin(anchorMin, duration).SetEase(easing),
                RectTransformSequenceType.DOAnchorPos => sequencer.DOAnchorPos(anchorPos, duration).SetEase(easing),
                RectTransformSequenceType.DOAnchorPos3D => sequencer.DOAnchorPos3D(anchorPos3D, duration).SetEase(easing),
                RectTransformSequenceType.DOPivot => sequencer.DOPivot(pivot, duration).SetEase(easing),
                RectTransformSequenceType.DOPunchAnchorPos => sequencer.DOPunchAnchorPos(punch, duration).SetEase(easing),
                RectTransformSequenceType.DOShakeAnchorPos => sequencer.DOShakeAnchorPos(duration, shake).SetEase(easing),
                RectTransformSequenceType.DOSizeDelta => sequencer.DOSizeDelta(size, duration).SetEase(easing),
                RectTransformSequenceType.DOShapeCircle => sequencer.DOShapeCircle(center, endValueDegrees, duration).SetEase(easing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}