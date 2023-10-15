using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    public class PresetController : MonoBehaviour
    {
        public List<Preset> presetList = new();

        public void SetPresetById(string _id)
        {
            for (int i = 0; i < presetList.Count; ++i)
            {
                if (_id == presetList[i].id)
                    presetList[i].Set();
            }
        }
    }
}