using System;
using Kuroneko.RuntimeUtility;
using Sirenix.OdinInspector;
using UnityEditor;
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
            resetSequence.Play(() =>
            {
                showSequence.Play(OnDoneShowing);
            });
        }

        [Button]
        public virtual void HidePopup()
        {
            isShowing = false;
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
