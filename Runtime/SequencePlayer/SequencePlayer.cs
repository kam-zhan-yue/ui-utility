using System;
using System.Collections;
using System.Collections.Generic;
using DG.DOTweenEditor;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Kuroneko.UIDelivery
{
    public class SequencePlayer : MonoBehaviour
    {
        public List<TweenData> tweenData = new();

        private Sequence ToSequence()
        {
            Sequence sequence = DOTween.Sequence();
            for (int i = 0; i < tweenData.Count; ++i)
            {
                tweenData[i].AttachToSequence(sequence);
            }
            return sequence;
        }

        public void AttachToSequence(Sequence sequence)
        {
            sequence.Append(ToSequence());
        }

        [Button]
        public void Play(Action onComplete = null)
        {
            if (Application.isPlaying)
            {
                Sequence sequence = ToSequence();
                sequence.Play().OnComplete(() =>
                {
                    onComplete?.Invoke();
                });
            }
            else if (Application.isEditor)
            {
                Sequence sequence = ToSequence();
                DOTweenEditorPreview.PrepareTweenForPreview(sequence);
                DOTweenEditorPreview.Start();
            }
        }
    }
}