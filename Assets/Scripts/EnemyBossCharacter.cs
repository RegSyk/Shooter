using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBossCharacter : Character
{
    private List<IDamageable> damageableToDamage = new List<IDamageable>();
    protected override void Start()
    {
        base.Start();
        StartCoroutine(DamagePlayerRoutine());
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != 7)
        {
            return;
        }
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable == null)
        {
            return;
        }

        if(!damageableToDamage.Contains(damageable))  damageableToDamage.Add(damageable);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer != 7)
        {
            return;
        }
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable == null)
        {
            return;
        }

        damageableToDamage.Remove(damageable);
    }

    private IEnumerator DamagePlayerRoutine()
    {
        while (this)
        {
            foreach (var damageable in damageableToDamage)
            {
                damageable.TakeDamage(10);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    public override void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        
        if (HealthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
