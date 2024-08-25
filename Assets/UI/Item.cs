using System;
using UnityEngine;

namespace UI
{
    public class Item : MonoBehaviour
    {
        public string Name = "Item";
        public int Width = 1;
        public int Height = 1;

        private void Awake()
        {
            InitializeItem();
        }

        private void InitializeItem()
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(Width * GridManager.GridWidth, Height * GridManager.GridHeight);
        }
    }
}