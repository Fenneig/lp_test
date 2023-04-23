using System;
using System.Collections.Generic;

namespace LavaProject.Systems
{
    [Serializable]
    public class InventorySaveData
    {
        public Dictionary<string, int> Data;

        public InventorySaveData()
        {
            Data = new Dictionary<string, int>();
        }
    }
}