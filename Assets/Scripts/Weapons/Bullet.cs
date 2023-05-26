using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public float Lifetime { get; set; } = 2;
    private void Awake()
    {
        Destroy(gameObject, Lifetime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != 9)
        {
            return;
        }
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable == null)
        {
            return;
        }

        damageable.TakeDamage(50);
        Destroy(gameObject);
    }
}
