using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public enum RectTransformSequenceType
    {
        DOScale = 0,
        DOScaleX,
        DOScaleY,
        DOScaleZ,
        DOMove,
        DOMoveX,
        DOMoveY,
        DOMoveZ,
    }
}