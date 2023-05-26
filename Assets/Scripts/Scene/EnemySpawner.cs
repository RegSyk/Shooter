using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemySpawner : MonoBehaviour
{
    public List<Character> EnemyCharacterPrefabs;
    public List<Character> EnemyCharacterSpawned = new List<Character>();
    public float SpawnDeltaTime = 2;
    public float CollisionDetectionDistance = 3;

    private IEnumerator Start()
    {
        while (this)
        {
            SpawnPoint sp = SpawnPoint.GetRandomSpawnPoint();
            bool collisionDetected = true;
            while (collisionDetected)
            {
                collisionDetected = false;

                foreach (Character character in EnemyCharacterSpawned)
                {
                    if (character != null && Vector3.Distance(character.transform.position, sp.transform.position) < CollisionDetectionDistance)
                    {
                        collisionDetected = true;
                        break;
                    }
                }

                if (PlayerSpawner.PlayerInstance != null && Vector3.Distance(PlayerSpawner.PlayerInstance.transform.position, sp.transform.position) < CollisionDetectionDistance)
                {
                    collisionDetected = true;
                }

                if (collisionDetected)
                {
                    sp = SpawnPoint.GetRandomSpawnPoint();
                }
                yield return null;
            }

            if(IsSpawnPointVisible(sp))
            {
                continue;
            }

            Character ch = Instantiate(EnemyCharacterPrefabs[UnityEngine.Random.Range(0, EnemyCharacterPrefabs.Count)], sp.transform.position, sp.transform.rotation);
            EnemyCharacterSpawned.Add(ch);
            
            yield return new WaitForSeconds(SpawnDeltaTime);
        }
    }

    public bool IsSpawnPointVisible(SpawnPoint sp)
    {
        Vector3 position = sp.transform.position;
        Vector3 viewportPosition = PlayerSpawner.PlayerInstance.CharacterCamera.WorldToViewportPoint(position);
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1 && viewportPosition.z > 0);
    }
}
