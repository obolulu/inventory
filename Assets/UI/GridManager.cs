using System;
using UnityEngine;

namespace UI
{
    public class GridManager : MonoBehaviour
    {
        public static int GridWidth = 64;
        public static int GridHeight = 64;
        public static GridManager Instance { get; private set; }
    
    
        [SerializeField] private InventoryGrid currentManipulatedGrid;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }


        private void Update()
        {
            if (currentManipulatedGrid == null)
            {
                return;
            }

            Vector2Int mousePositionOnGrid = GetMousePositionOnGrid();
            Debug.Log(mousePositionOnGrid);
            
        }


        private Vector2Int GetMousePositionOnGrid()
        {
            if (currentManipulatedGrid == null)
            {
                Debug.LogError("No grid is being manipulated");
                return Vector2Int.zero;
            }

            Vector3 mouseScreenPosition = Input.mousePosition;

            RectTransform gridRectTransform = currentManipulatedGrid.GetComponent<RectTransform>();
            Canvas canvas = gridRectTransform.GetComponentInParent<Canvas>();

            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                gridRectTransform,
                mouseScreenPosition,
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main,
                out localPoint
            );

            localPoint.y = -localPoint.y;

            int x = Mathf.FloorToInt(localPoint.x / GridManager.GridWidth);
            int y = Mathf.FloorToInt(localPoint.y / GridManager.GridHeight);

            return new Vector2Int(x, y);
        }

        
        public void SetManipulatedGrid(InventoryGrid inventoryGrid)
        {
            currentManipulatedGrid = inventoryGrid;
        }
    
    }
}
