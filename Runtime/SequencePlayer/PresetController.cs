using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kuroneko.UIUtility
{
    [Serializable]
    public class PresetController : MonoBehaviour
    {
        [TableList]
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