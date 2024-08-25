using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UI
{
    public class InventoryGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public int width = 5;
        public int height = 5;

        private Item[,] _items;


        private void Awake()
        {
            InitializeGrid();
        }

        
        private void InitializeGrid()
        {
            _items = new Item[width, height];
            GetComponent<RectTransform>().sizeDelta = new Vector2(width * GridManager.GridWidth, height * GridManager.GridHeight);
        }



        public void PlaceItemOnGrid(Item itemToPlace, Vector2Int positionOnGrid)
        {
            if (itemToPlace == null)
            {
                return;
            }
            
            for (int x = 0; x < itemToPlace.Width; x++)
            {
                for (int y = 0; y < itemToPlace.Height; y++)
                {
                    Vector2Int gridPosition = GetGridPosition(positionOnGrid + new Vector2Int(x, y));
                    _items[gridPosition.x, gridPosition.y] = itemToPlace;
                }
            }
            
            
            
        }
        
        

        
        public Vector2Int GetGridPosition(Vector2Int rawPositionOnGrid)
        {
            return new Vector2Int(
                Mathf.Clamp(rawPositionOnGrid.x, 0, width - 1),
                Mathf.Clamp(rawPositionOnGrid.y, 0, height - 1)
            );
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            GridManager.Instance.SetManipulatedGrid(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GridManager.Instance.SetManipulatedGrid(null);
        }
    }
}
