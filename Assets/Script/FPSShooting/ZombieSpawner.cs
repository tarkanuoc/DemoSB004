using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    public int spawnQuantity;
    public float spawnInterval;
    public float spawnRadius = 10f;
    public Color color;
    private void OnDrawGizmos()
    {
        Handles.color = color;
        Handles.DrawSolidDisc(transform.position, Vector3.up, spawnRadius);
    }

    private void Start()
    {
        StartCoroutine(SpawnZombieByTime());
    }

    IEnumerator SpawnZombieByTime()
    {
        while (spawnQuantity > 0)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnZombie()
    {
        Vector3 spawnPos = Random.insideUnitCircle * spawnRadius;

        Instantiate(zombiePrefab, transform.position + spawnPos, transform.rotation);
        spawnQuantity--;
    }


}
