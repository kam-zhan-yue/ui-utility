using System;
using Sirenix.OdinInspector;

namespace Kuroneko.UIDelivery
{
    [Serializable]
    public class Preset
    {
        public string id = string.Empty;
        
        [TableColumnWidth(200)]
        public SequencePlayer sequencePlayer;

        [TableColumnWidth(150)]
        [Button, VerticalGroup("Actions")]
        public void Set()
        {
            sequencePlayer.Play();
        }
    }
}