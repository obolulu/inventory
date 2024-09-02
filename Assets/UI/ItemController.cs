using UnityEngine;

namespace UI
{
    public class ItemController : MonoBehaviour
    {
        public static ItemController Instance { get; private set; }

        public Item currentHeldItem;

        public Item itemPrefab;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            ManipulateHeldItem();
        }

        private void ManipulateHeldItem()
        {
            if (currentHeldItem == null)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    currentHeldItem = Instantiate(itemPrefab, transform);
                }
                else
                {
                    return;
                }
            }


            // Vector2Int mousePositionOnGrid = GridManager.Instance.GetMousePositionOnGrid();
            // currentHeldItem.transform.position = new Vector3(mousePositionOnGrid.x * GridManager.GridWidth,
            //     -mousePositionOnGrid.y * GridManager.GridHeight);
        }
    }
}