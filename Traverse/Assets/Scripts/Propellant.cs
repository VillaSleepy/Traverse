using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Propellant : MonoBehaviour
{
    private Rigidbody2D _missile;
    [SerializeField] private int _speed;

    void Start()
    {
        _missile = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _missile.velocity = _missile.transform.up * _speed;

        if (_missile.velocity == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }



}
