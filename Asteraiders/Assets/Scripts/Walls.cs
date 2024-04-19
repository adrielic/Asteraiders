using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private BoxCollider2D wallBoxCol;

    void Start()
    {
        InitializeComponents();
    }

    void Update()
    {

    }

    void InitializeComponents()
    {
        gameObject.AddComponent<BoxCollider2D>();
        wallBoxCol = gameObject.GetComponent<BoxCollider2D>();

        if (gameObject.name == "LeftWall(Clone)" || gameObject.name == "RightWall(Clone)")
        {
            wallBoxCol.edgeRadius = 1.0f;
        }
    }
}
