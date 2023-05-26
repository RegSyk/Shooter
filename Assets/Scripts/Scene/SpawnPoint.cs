using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

    public static SpawnPoint GetRandomSpawnPoint() => SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)];

    public static SpawnPoint GetFirstSpawnPoint() => SpawnPoints[0];

    public void Awake() => SpawnPoints.Add(this);

    private void OnDestroy() => SpawnPoints.Remove(this);
}
