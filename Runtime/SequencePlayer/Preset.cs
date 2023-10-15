using System;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class Preset
    {
        public string id = string.Empty;
        public SequencePlayer sequencePlayer;

        public void Set()
        {
            sequencePlayer.Play();
        }
    }
}