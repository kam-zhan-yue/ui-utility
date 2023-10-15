using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public enum GameObjectSequenceType
    {
        DOScale = 0,
        DOScaleX,
        DOScaleY,
        DOScaleZ,
        DOMove,
        DOMoveX,
        DOMoveY,
        DOMoveZ,
        DOLocalMove,
        DOLocalMoveX,
        DOLocalMoveY,
        DOLocalMoveZ,
        DORotate,
        DOLocalRotate
    }
}