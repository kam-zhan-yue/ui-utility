using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public enum RectTransformSequenceType
    {
        DOAnchorMax = 0,
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