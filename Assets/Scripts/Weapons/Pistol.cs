using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pistol : Weapon
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
