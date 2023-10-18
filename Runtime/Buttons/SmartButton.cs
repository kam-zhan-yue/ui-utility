using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Kuroneko.UIUtility
{
    public class SmartButton : Button, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private PresetController m_presetController;
        [SerializeField] private TMP_Text m_text;
        
        [BoxGroup("UI Objects")] public PresetController PresetController => m_presetController;

        [BoxGroup("UI Objects")]
        public TMP_Text Text => m_text;

        public Action<PointerEventData> onPointerClick;
        public Action<PointerEventData> onPointerDown;
        public Action<PointerEventData> onPointerUp;
        public Action<PointerEventData> onPointerEnter;
        public Action<PointerEventData> onPointerExit;
        public Action<PointerEventData> onBeginDrag;
        public Action<PointerEventData> onEndDrag;

        public void SetPresetById(string _id)
        {
            if(PresetController)
                PresetController.SetPresetById(_id);
        }

        public void SetText(string _text)
        {
            if(Text)
                Text.SetText(_text);
        }
        
        public override void OnPointerClick(PointerEventData _eventData)
        {
            base.OnPointerClick(_eventData);
            onPointerClick?.Invoke(_eventData);
        }

        public override void OnPointerDown(PointerEventData _eventData)
        {
            base.OnPointerDown(_eventData);
            onPointerDown?.Invoke(_eventData);
        }

        public override void OnPointerUp(PointerEventData _eventData)
        {
            base.OnPointerUp(_eventData);
            onPointerUp?.Invoke(_eventData);
        }

        public override void OnPointerEnter(PointerEventData _eventData)
        {
            base.OnPointerEnter(_eventData);
            onPointerEnter?.Invoke(_eventData);
        }

        public override void OnPointerExit(PointerEventData _eventData)
        {
            base.OnPointerExit(_eventData);
            onPointerExit?.Invoke(_eventData);
        }

        public void OnBeginDrag(PointerEventData _eventData)
        {
            onBeginDrag?.Invoke(_eventData);
        }

        public void OnEndDrag(PointerEventData _eventData)
        {
            onEndDrag?.Invoke(_eventData);
        }
    }
}