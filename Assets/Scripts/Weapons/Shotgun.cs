using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [Header("Shotgun settings")]
    [SerializeField] private float bulletOffset = 0.05f;
    public override void Fire()
    {
        if (!Reloading)
        {
            List<Rigidbody> bulletInstances= new List<Rigidbody>();

            Rigidbody bulletInstance1 =
                Instantiate(BulletPrefab, FireTransformPoint.position, FireTransformPoint.rotation) as Rigidbody;
            Rigidbody bulletInstance2 =
                Instantiate(BulletPrefab, FireTransformPoint.position + FireTransformPoint.right * bulletOffset, FireTransformPoint.rotation * Quaternion.Euler(0, 10, 0)) as Rigidbody;
            Rigidbody bulletInstance3 =
                Instantiate(BulletPrefab, FireTransformPoint.position - FireTransformPoint.right * bulletOffset, FireTransformPoint.rotation * Quaternion.Euler(0, -10, 0)) as Rigidbody;

            bulletInstances.Add(bulletInstance1);
            bulletInstances.Add(bulletInstance2);
            bulletInstances.Add(bulletInstance3);

            foreach (var bulletInstance in bulletInstances)
            {
                bulletInstance.velocity = LaunchSpeed * bulletInstance.transform.forward + ParentVelocity;
                bulletInstance.useGravity = false;
            }
        }
    }
}
