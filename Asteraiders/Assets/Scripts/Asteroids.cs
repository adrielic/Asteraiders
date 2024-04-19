using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private PolygonCollider2D asteroidPolyCol;
    private Rigidbody2D asteroidRb;
    private Animator asteroidAnim;

    public RuntimeAnimatorController asteroidAnimController;

    void Start()
    {
        InitializeComponents();
    }

    void Update()
    {
        MoveAsteroids();
    }

    void InitializeComponents()
    {
        gameObject.AddComponent<PolygonCollider2D>();
        asteroidPolyCol = gameObject.GetComponent<PolygonCollider2D>();

        gameObject.AddComponent<Rigidbody2D>();
        asteroidRb = gameObject.GetComponent<Rigidbody2D>();
        asteroidRb.bodyType = RigidbodyType2D.Kinematic;

        gameObject.AddComponent<Animator>();
        asteroidAnim = gameObject.GetComponent<Animator>();
        asteroidAnim.runtimeAnimatorController = asteroidAnimController;
    }

    void MoveAsteroids()
    {
        transform.Translate(new Vector2(GameController.gameSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "CleaningZone")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Projectile")
        {
            asteroidAnim.Play("Cracking");
            Destroy(gameObject.GetComponent("PolygonCollider2D"));
        }
    }
}
