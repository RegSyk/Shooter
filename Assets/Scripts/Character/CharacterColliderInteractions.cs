using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColliderInteractions : MonoBehaviour
{
    public List<Collider> MyColliders;
    private void Awake()
    {
        foreach (var collider in MyColliders)
        {
            foreach(var collider2 in MyColliders)
            {
                if(collider != collider2) Physics.IgnoreCollision(collider, collider2);
            }
        }
    }
}
