﻿using LavaProject.Inventory.Abstract;
using UnityEngine;

namespace LavaProject.Assets
{
    [CreateAssetMenu(menuName = "Assets/CollectableItem", fileName = "CollectableItem")]
    public class ItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string _id;
        [Space][Header("UI Info")]
        [SerializeField] private Sprite _icon;

        [Space] [Header("Gameplay info")]
        [SerializeField] private GameObject _visualPrefab;
        [SerializeField] private float _prepareToCollectTime;
        [Space][Header("Mine visual info")]
        [SerializeField] private float _moveFromMineTime;
        [SerializeField] private float _jumpForce;
        [SerializeField] private int _jumpsAmount;

        public string Id => _id;
        public Sprite SpriteIcon => _icon;
        public GameObject VisualPrefab => _visualPrefab;
        public float PrepareToCollectTime => _prepareToCollectTime;
        public float MoveFromMineTime => _moveFromMineTime;
        public float JumpForce => _jumpForce;
        public int JumpsAmount => _jumpsAmount;
    }
}