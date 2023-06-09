﻿using LavaProject.World;
using UnityEngine;

namespace LavaProject.Characters
{
    public class MiningComponent : MonoBehaviour
    {
        public MineObject CurrentMine { private get; set; }
        public bool IsMining { get; set; }

        public void PickaxeHit()
        {
            if (CurrentMine != null)
                CurrentMine.Extract();
        }
    }
}