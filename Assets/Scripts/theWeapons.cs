using System;
using System.Collections;
using UnityEngine;

public class theWeapons : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private float _cooldown = 3f;
    [SerializeField] KeyCode _input = KeyCode.Mouse0;
    [SerializeField] KeyCode _weaponSwap = KeyCode.E;

    [Header("Variations")]
    [SerializeField] private Projectile _projectile1;
    [SerializeField] private Projectile _projectile2;
    [SerializeField] private Projectile _projectile3;
    private Projectile _actualProjectile;

    private int _weaponIndex;

    private bool _onCooldown = false;

    private void Start()
    {
        _actualProjectile = _projectile1;
        _weaponIndex = 0;
    }

    void Update()
    {
        //Allows player to shoot the selected bullet
        if (Input.GetKey(_input) && !_onCooldown)
        {
            Shoot();
        }

        //It change the prefab for the instance process
        if (Input.GetKey(_weaponSwap))
        {
            Change();
        }

    }

    //Changes the index of the weapon
    private void Change()
    {
        if (_weaponIndex == 2)
        {
            _weaponIndex = 0;
        }
        else
        {
            _weaponIndex++;
        }
    }

    //Instantiate the selected bullet
    private void Shoot()
    {
        switch (_weaponIndex)
        {
            case 0:
                _actualProjectile = _projectile1;
                break;
            case 1:
                _actualProjectile = _projectile2;
                break;
            case 2:
                _actualProjectile = _projectile3;
                break;
        }
        Instantiate(_actualProjectile, transform.position, transform.rotation);
        StartCoroutine(CooldownCoro());
    }

    //Sets teh cooldown inside each shot
    private IEnumerator CooldownCoro()
    {
        _onCooldown = true;
        yield return new WaitForSeconds(_cooldown);
        _onCooldown = false;
    }
}
