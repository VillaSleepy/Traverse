using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public Rigidbody2D bullet;

    [SerializeField] private int _speed;

    [SerializeField] private int bounceMax;
    private int bounceAmount = 0;
    private float currentSpeed;

    private Vector2 direction;
    private Vector2 lastVelocity;


    private void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = bullet.transform.up * _speed;
    }

    private void Update()
    {
        lastVelocity = bullet.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (bounceAmount >= bounceMax) Destroy(gameObject);

        currentSpeed = lastVelocity.magnitude;
        direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        bullet.velocity = direction * currentSpeed;
        bounceAmount++;
    }

    //public void AddPlayerReference(Rigidbody2D player)
    //{
        //_player = player;
    //}


}
