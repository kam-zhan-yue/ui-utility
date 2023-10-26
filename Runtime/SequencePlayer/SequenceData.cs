using System;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Kuroneko.UIDelivery
{
    [Serializable]
    public class SequenceData
    {
        public const float WIDTH = 120f;
        public const float SPACE = 10f;

        [HideLabel, HorizontalGroup("SequenceSettings", WIDTH)] [PropertySpace(SPACE)]
        public SequenceType type = SequenceType.Append;

        [HideLabel, HorizontalGroup("SequenceSettings", WIDTH)] [PropertySpace(SPACE)]
        public SequenceObject sequencer = SequenceObject.GameObject;
        
        [Title("Sequence Details")]
        [HideLabel, ShowIf("sequencer", SequenceObject.GameObject)]
        public GameObjectSequence gameObject = new();
        
        [HideLabel, ShowIf("sequencer", SequenceObject.RectTransform)]
        public RectTransformSequence rectTransform = new();

        [HideLabel, ShowIf("sequencer", SequenceObject.Image)]
        public ImageSequence image = new();

        [HideLabel, ShowIf("sequencer", SequenceObject.CanvasGroup)]
        public CanvasGroupSequence canvasGroup = new();

        public void AttachToSequence(Sequence _sequence)
        {
            switch (sequencer)
            {
                case SequenceObject.GameObject:
                    gameObject.AttachToSequence(_sequence, type);
                    break;
                case SequenceObject.RectTransform:
                    rectTransform.AttachToSequence(_sequence, type);
                    break;
                case SequenceObject.Image:
                    image.AttachToSequence(_sequence, type);
                    break;
                case SequenceObject.CanvasGroup:
                    canvasGroup.AttachToSequence(_sequence, type);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}