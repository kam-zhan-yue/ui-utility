using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIDelivery
{
    public abstract class Popup : MonoBehaviour
    {
        [BoxGroup("UI Objects")]
        public RectTransform mainHolder;

        [BoxGroup("Sequences")] public SequencePlayer showSequence;
        [BoxGroup("Sequences")] public SequencePlayer hideSequence;
        [BoxGroup("Sequences")] public SequencePlayer resetSequence;
        
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
            isShowing = true;
            isAnimating = true;
            resetSequence.Play(() =>
            {
                showSequence.Play(OnDoneShowing);
            });
        }

        [Button]
        public virtual void HidePopup()
        {
            isShowing = false;
            isAnimating = true;
            hideSequence.Play(OnDoneHiding);
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
