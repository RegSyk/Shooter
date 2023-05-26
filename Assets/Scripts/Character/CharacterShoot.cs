using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CharacterWeapon _characterWeapon;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!_characterWeapon.WeaponChosen.Reloading)
            {
                _characterWeapon.WeaponChosen.Fire();
                _characterWeapon.WeaponChosen.Reload();
            }
        }
    }
}
