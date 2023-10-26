using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIDelivery
{
    [Serializable]
    public abstract class SequenceTween
    {
        [HideLabel, HorizontalGroup("SequencePlayData", SequenceData.WIDTH)]
        public Ease easing = Ease.Linear;
        
        [HideLabel, HorizontalGroup("SequencePlayData", SequenceData.WIDTH)]
        public float duration;

        public abstract Tween ToTween();

        public void AttachToSequence(Sequence _sequence, SequenceType _type)
        {
            switch (_type)
            {
                case SequenceType.Append:
                    Append(_sequence);
                    break;
                case SequenceType.Join:
                    Join(_sequence);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_type), _type, null);
            }
        }

        private void Append(Sequence _sequence)
        {
            _sequence.Append(ToTween());
        }

        private void Join(Sequence _sequence)
        {
            _sequence.Join(ToTween());
        }
    }
    
}