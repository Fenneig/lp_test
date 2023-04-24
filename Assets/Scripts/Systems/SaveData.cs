using System;
using System.Collections.Generic;

namespace LavaProject.Systems
{
    [Serializable]
    public class SaveData
    {
        public Dictionary<string, int> Data;
        public bool IsTutorialComplete;

        public SaveData()
        {
            Data = new Dictionary<string, int>();
        }
    }
}