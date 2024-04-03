using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kuroneko.UIDelivery
{
    [Serializable]
    public enum RectTransformSequenceType
    {
        DOMove,
        DOMoveX,
        DOMoveY,
        DOMoveZ,
        DOAnchorMax,
        DOAnchorMin,
        DOAnchorPos,
        DOAnchorPos3D,
        DOPivot,
        DOPunchAnchorPos,
        DOShakeAnchorPos,
        DOSizeDelta,
        DOShapeCircle
    }
}