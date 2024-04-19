using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLoop : MonoBehaviour
{
    public Renderer quad;

    void Start()
    {

    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.deltaTime * GameController.gameSpeed / -10, 0);
        quad.material.mainTextureOffset += offset;
        Debug.Log("Quad speed: " + GameController.gameSpeed / -10);
    }
}
