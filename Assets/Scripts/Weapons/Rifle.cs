using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void Fire()
    {
        if (!Reloading)
        {
            Rigidbody bulletInstance =
            Instantiate(BulletPrefab, FireTransformPoint.position, FireTransformPoint.rotation) as Rigidbody;
            bulletInstance.velocity = LaunchSpeed * FireTransformPoint.forward + ParentVelocity;
            bulletInstance.useGravity = false;
        }
    }
}
