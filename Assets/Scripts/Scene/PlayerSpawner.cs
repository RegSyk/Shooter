using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public bool Random = true;
    public static Character PlayerInstance;
    public Character PlayerCharacterPrefab;

    private void Start() => SpawnPlayer();

    public void SpawnPlayer() 
    {
        SpawnPoint sp;
        if (Random)
        {
             sp = SpawnPoint.GetRandomSpawnPoint();
        }
        else
        {
            sp = SpawnPoint.GetFirstSpawnPoint();
        }
        PlayerInstance = Instantiate(PlayerCharacterPrefab, sp.transform.position, sp.transform.rotation); 
    }
}
