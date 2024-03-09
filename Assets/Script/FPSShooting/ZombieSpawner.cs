using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    public int spawnQuantity;
    public float spawnInterval;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.27f);
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
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        spawnQuantity--;
    }


}
