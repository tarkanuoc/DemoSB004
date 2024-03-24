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
    public float traceDistance = 20f;

    private List<ZombieAI> _lstZombieAI = new List<ZombieAI>();

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

        var zombie = Instantiate(zombiePrefab, transform.position + spawnPos, transform.rotation);
        var zombieAI = zombie.GetComponent<ZombieAI>();
        zombieAI.SpawnPos = transform;
        _lstZombieAI.Add(zombieAI);
        spawnQuantity--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("=========== Player In");
            for (int i = 0; i < _lstZombieAI.Count; i++)
            {
                //if (Vector3.Distance(other.transform.position, _lstZombieAI[i].transform.position) <= traceDistance)
                {
                    _lstZombieAI[i].TracePlayer();
                }
            }
        }
    }

}
