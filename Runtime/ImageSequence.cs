using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class ImageSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public Image type;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public ImageSequenceType sequencer;

        public override Tween ToTween()
        {
            throw new NotImplementedException();
        }
    }
}