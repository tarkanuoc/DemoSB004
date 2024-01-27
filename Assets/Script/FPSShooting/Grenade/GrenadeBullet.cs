using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    public float exposionForce;
    public float exposionRadius;


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        BlowObjects();
    }

    private void BlowObjects()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, exposionRadius);

        for (int i = 0; i < affectedObjects.Length; i++)
        {
            var rigibody = affectedObjects[i].attachedRigidbody;
            if (rigibody != null)
            {
                rigibody.AddExplosionForce(exposionForce, transform.position, exposionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
