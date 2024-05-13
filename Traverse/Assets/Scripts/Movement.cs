using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;

    private float _horizontalMovement;
    private float _verticalMovement;

    private bool _canMove = true;
    private bool _dashCooldown = true;

    [SerializeField] private float _dashSpeed;
    [SerializeField] private int _movementSpeed = 10;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_canMove && Input.GetButtonDown("Jump") && _dashCooldown)
        {
            StartCoroutine(PlayerDash());
        }

        if (_canMove)
        {
            PlayerMovement();
        }
    }


    private IEnumerator PlayerDash()
    {
        _canMove = false;
        _dashCooldown = false;
        player.velocity = new Vector2(player.velocity.x, player.velocity.y) * _dashSpeed;
        yield return new WaitForSeconds(0.09f);
        player.velocity = Vector2.zero;
        _canMove = true;
        yield return new WaitForSeconds(3);
        _dashCooldown = true;
    }

    private void PlayerMovement()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

        player.velocity = new Vector2(_horizontalMovement, _verticalMovement).normalized * _movementSpeed;
    }

}
