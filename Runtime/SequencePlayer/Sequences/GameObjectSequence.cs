using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class GameObjectSequence : SequenceTween
    {
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public GameObjectSequenceType type;
        
        [HideLabel, HorizontalGroup("SequenceData", SequenceData.WIDTH)]
        public GameObject sequencer;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOScale)]
        public Vector3 scale;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOScaleX)]
        public float scaleX;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOScaleY)]
        public float scaleY;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOScaleZ)]
        public float scaleZ;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOMove)]
        public Vector3 move;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOMoveX)]
        public float moveX;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOMoveY)]
        public float moveY;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOMoveZ)]
        public float moveZ;

        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOLocalMove)]
        public Vector3 localMove;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOLocalMoveX)]
        public float localMoveX;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOLocalMoveY)]
        public float localMoveY;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOLocalMoveZ)]
        public float localMoveZ;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DORotate)]
        public Vector3 rotate;
        
        [HideLabel, HorizontalGroup("SequenceData"), ShowIf("type", GameObjectSequenceType.DOLocalRotate)]
        public Vector3 localRotate;
        
        public override Tween ToTween()
        {
            return type switch
            {
                GameObjectSequenceType.DOScale => sequencer.transform.DOScale(scale, duration).SetEase(easing),
                GameObjectSequenceType.DOScaleX => sequencer.transform.DOScaleX(scaleX, duration).SetEase(easing),
                GameObjectSequenceType.DOScaleY => sequencer.transform.DOScaleY(scaleY, duration).SetEase(easing),
                GameObjectSequenceType.DOScaleZ => sequencer.transform.DOScaleZ(scaleZ, duration).SetEase(easing),
                GameObjectSequenceType.DOMove => sequencer.transform.DOMove(move, duration).SetEase(easing),
                GameObjectSequenceType.DOMoveX => sequencer.transform.DOMoveX(moveX, duration).SetEase(easing),
                GameObjectSequenceType.DOMoveY => sequencer.transform.DOMoveY(moveY, duration).SetEase(easing),
                GameObjectSequenceType.DOMoveZ => sequencer.transform.DOMoveZ(moveZ, duration).SetEase(easing),
                GameObjectSequenceType.DOLocalMove => sequencer.transform.DOLocalMove(localMove, duration).SetEase(easing),
                GameObjectSequenceType.DOLocalMoveX => sequencer.transform.DOLocalMoveX(localMoveX, duration).SetEase(easing),
                GameObjectSequenceType.DOLocalMoveY => sequencer.transform.DOLocalMoveY(localMoveY, duration).SetEase(easing),
                GameObjectSequenceType.DOLocalMoveZ => sequencer.transform.DOLocalMoveZ(localMoveZ, duration).SetEase(easing),
                GameObjectSequenceType.DORotate => sequencer.transform.DORotate(rotate, duration).SetEase(easing),
                GameObjectSequenceType.DOLocalRotate => sequencer.transform.DOLocalRotate(localRotate, duration).SetEase(easing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}