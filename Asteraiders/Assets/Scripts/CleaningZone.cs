using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningZone : MonoBehaviour
{
    private Rigidbody2D czRb;
    private BoxCollider2D czBoxCol;

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
        czBoxCol = gameObject.GetComponent<BoxCollider2D>();
        czBoxCol.isTrigger = true;

        gameObject.AddComponent<Rigidbody2D>();
        czRb = gameObject.GetComponent<Rigidbody2D>();
        czRb.bodyType = RigidbodyType2D.Kinematic;
    }
}
