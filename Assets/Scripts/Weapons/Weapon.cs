using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: Header("Weapon Dependencies")]
    [field: SerializeField] public Transform FireTransformPoint {get; set;}
    [SerializeField] protected Rigidbody BulletPrefab;
    [Space]
    [Header("Weapon Settings")]
    [SerializeField] protected float LaunchSpeed;
    [SerializeField] protected float ReloadTime;
    [SerializeField] protected float ReloadCounter;

    protected Vector3 ParentVelocity;
    private Vector3 previousPosition;

    [field: Header("Debug")]
    [field: SerializeField] public bool Reloading { get; private set; } = false;
    public abstract void Fire();
    public virtual void Reload()
    {
        Reloading = true;
    }

    protected virtual void FixedUpdate()
    {
        if (Reloading)
        {
            ReloadCounter += Time.fixedDeltaTime;
            if(ReloadCounter >= ReloadTime)
            {
                Reloading = false;
                ReloadCounter = 0;
            }
        }
        CalculateParentVelocity();
    }

    private void CalculateParentVelocity()
    {
        ParentVelocity = (transform.position - previousPosition)/Time.fixedDeltaTime;
        previousPosition = transform.position;
    }

}
