using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoxCollider2D projBoxCol;

    void Start()
    {
        InitializeComponents();
    }

    void Update()
    {
        MoveProjectile();
        Destroy(gameObject, 1.6f);
    }

    void InitializeComponents()
    {
        gameObject.AddComponent<BoxCollider2D>();
        projBoxCol = gameObject.GetComponent<BoxCollider2D>();
        projBoxCol.isTrigger = true;
    }

    void MoveProjectile()
    {
        transform.Translate(new Vector2(10 * Time.deltaTime, 0));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(col.gameObject, 1);
            Score.currentScore += 10;
            Debug.Log("Score: " + Score.currentScore);
        }
    }
}
