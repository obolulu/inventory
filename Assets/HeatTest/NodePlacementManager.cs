using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodePlacementManager : MonoBehaviour
{
    public bool IsPlacing = true;
    
    public GameObject NodePrefab;
    public GameObject Parent;

    public int NodeCount = 0;

    
    

    private void Update()
    {
        if (IsPlacing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceNodeAtMouse();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FinalizePlacement();
            }
        }

    }


    public void PlaceNodeAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        GameObject newNode = Instantiate(NodePrefab, mousePos, Quaternion.identity, Parent.transform);
        
        Parent.GetComponent<MapMB>().Nodes.Add(newNode.GetComponent<NodeMB>());
        
        newNode.GetComponent<NodeMB>().NodeIndex = NodeCount;
        NodeCount++;
    }

    public void FinalizePlacement()
    {
        Parent.GetComponent<MapMB>().Nodes.Sort((a, b) => a.NodeIndex.CompareTo(b.NodeIndex));
        IsPlacing = false;
    }
}
