using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [field: SerializeField] public Weapon WeaponChosen { get; private set; }

    [SerializeField] private Transform WeaponSpawnPoint;
    [SerializeField] private List<Weapon> WeaponPrefabs;
    [SerializeField] private List<Weapon> WeaponInstances;
    [SerializeField] private byte WeaponChosenIndex = 0;
    [SerializeField] private Rigidbody ParentRigidbody;

    private void Awake()
    {
        WeaponInstances = new List<Weapon>();
    }

    private void Start()
    {
        foreach(var weapon in WeaponPrefabs)
        {
            Weapon instance = Instantiate(WeaponPrefabs[WeaponChosenIndex], WeaponSpawnPoint.position, WeaponSpawnPoint.rotation) as Weapon;
            instance.transform.parent = WeaponSpawnPoint.transform;
            WeaponInstances.Add(instance);
            instance.gameObject.SetActive(false);
            WeaponChosenIndex++;
        }
        WeaponChosenIndex = 0;
        WeaponChosen = WeaponInstances[WeaponChosenIndex];
        UpdateWeapon();
    }

    private void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll > 0f)
        {
            SwitchWeaponUp();
        }
        else if (scroll < 0f)
        {
            SwitchWeaponDown();
        }
    }

    public void SwitchWeaponUp()
    {
        if(WeaponChosenIndex < WeaponInstances.Count - 1)
        {
            WeaponChosenIndex++;
            UpdateWeapon();
        }
    }

    public void SwitchWeaponDown()
    {
        if (WeaponChosenIndex > 0)
        {
            WeaponChosenIndex--;
            UpdateWeapon();
        }
    }

    private void UpdateWeapon()
    {
        foreach(var weapon in WeaponInstances)
        {
            if (WeaponInstances.IndexOf(weapon) != WeaponChosenIndex)
            {
                weapon.gameObject.SetActive(false);
            }
        }
        WeaponInstances[WeaponChosenIndex].gameObject.SetActive(true);
        WeaponChosen = WeaponInstances[WeaponChosenIndex];
    }
}
