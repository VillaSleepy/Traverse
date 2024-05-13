using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _missilePrefab;
    private Transform missileInstance;

    private bool _currentWeapon = true;
    //public bool missileShot = false;

    void Update()
    {
        LookAtMouse();

        if (Input.GetKeyDown(KeyCode.Mouse0) && _currentWeapon == true)
        {
            Shoot();
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && _currentWeapon == false)
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.E) && _currentWeapon == false)
        {
            _currentWeapon = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && _currentWeapon == true)
        {
            _currentWeapon = false;
        }
        if (missileInstance != null && missileInstance.rotation != _player.rotation)
        {
            missileInstance.rotation = _player.rotation;
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - (Vector2)transform.position);
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
        //Physics2D.IgnoreCollision(_player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Launch()
    {
        missileInstance = Instantiate(_missilePrefab, transform.position, transform.rotation);

    }



}
