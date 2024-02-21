using System;
using Kuroneko.UtilityDelivery;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIDelivery
{
    public abstract class Popup : MonoBehaviour
    {
        [BoxGroup("UI Objects")]
        public RectTransform mainHolder;

        [BoxGroup("Sequences")] public bool usingSequences;
        [BoxGroup("Sequences"), ShowIf("usingSequences")] public SequencePlayer showSequence;
        [BoxGroup("Sequences"), ShowIf("usingSequences")] public SequencePlayer hideSequence;
        [BoxGroup("Sequences"), ShowIf("usingSequences")] public SequencePlayer resetSequence;
        
        [NonSerialized, ShowInInspector, ReadOnly]
        public bool isAnimating = false;
    
        [NonSerialized, ShowInInspector, ReadOnly]
        public bool isShowing = false;
    
        public Action<Popup> onCloseButtonClicked = null;
        public Action<Popup> onDoneShowing = null;
        public Action<Popup> onDoneHiding = null;

        private void Awake()
        {
            InitPopup();
        }

        protected abstract void InitPopup();

        [Button]
        public virtual void ShowPopup()
        {
            if (usingSequences)
            {
                isAnimating = true;
                resetSequence.Play(() =>
                {
                    showSequence.Play(OnDoneShowing);
                });
            }
            else
            {
                isShowing = true;
                mainHolder.gameObject.SetActiveFast(true);
            }
        }

        [Button]
        public virtual void HidePopup()
        {
            if (usingSequences)
            {
                isAnimating = true;
                hideSequence.Play(OnDoneHiding);
            }
            else
            {
                isShowing = false;
                mainHolder.gameObject.SetActiveFast(false);
            }
        }

        protected virtual void OnDoneShowing()
        {
            isShowing = true;
            isAnimating = false;
            onDoneShowing?.Invoke(this);   
        }

        protected virtual void OnDoneHiding()
        {
            isShowing = false;
            isAnimating = false;
            onDoneHiding?.Invoke(this);
        }
    
        public virtual void CloseButtonClicked()
        {
            onCloseButtonClicked?.Invoke(this);
        }

        public virtual void EscapeButtonClicked()
        {
            CloseButtonClicked();
        }
    }
}
