using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatGameManager : MonoBehaviour
{
    public int CursorIndex = 0;
    public PlayerMB Player;
    
    
    public MapMB ActiveMap;


    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerMB>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InitializePlayerPosition();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayerToNextPosition();
        }
    }



    public void InitializePlayerPosition()
    {
        Player.CurrentIndex = 0;
        CursorIndex = 0;
        Player.transform.position = ActiveMap.Nodes[0].transform.position;
    }

    public void MovePlayerToNextPosition()
    {
        if (CursorIndex >= ActiveMap.Nodes.Count - 1)
        {
            CursorIndex = -1;
        }
        
        CursorIndex++;
        
        MovePlayerToPosition(CursorIndex);

    }
    
    public void MovePlayerToPosition(int index)
    {
            Player.CurrentIndex = index;
            Player.transform.position = ActiveMap.Nodes[index].transform.position;
    }
}
