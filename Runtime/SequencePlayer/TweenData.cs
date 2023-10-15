using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class TweenData
    {
        [HideLabel] [GUIColor("GetTweenTypeColour")]
        public TweenType type = TweenType.Sequence;

        [HideLabel, ShowIf("type", TweenType.Sequence)]
        public SequenceData sequenceData = new();

        [HideLabel, ShowIf("type", TweenType.Callback)]
        public UnityEvent callback;
        
        [HideLabel, ShowIf("type", TweenType.Interval)]
        public float interval;

        public void AttachToSequence(Sequence _sequence)
        {
            switch (type)
            {
                case TweenType.Sequence:
                    sequenceData.AttachToSequence(_sequence);
                    break;
                case TweenType.Callback:
                    _sequence.AppendCallback(ActivateEvent);
                    break;
                case TweenType.Interval:
                    _sequence.AppendInterval(interval);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ActivateEvent()
        {
            callback?.Invoke();
        }
        
        private Color GetTweenTypeColour()
        {
            switch (type)
            {
                case TweenType.Sequence:
                    return Color.green;
                case TweenType.Callback:
                    return Color.red;
                case TweenType.Interval:
                    return Color.grey;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}