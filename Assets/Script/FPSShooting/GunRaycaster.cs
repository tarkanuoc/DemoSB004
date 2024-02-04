using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private Camera aimingCamera;
    [SerializeField] private LayerMask layerMask;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, -transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitinfo, 1000f, layerMask))
        {
            var effectRotation = Quaternion.LookRotation(hitinfo.normal);
            Instantiate(hitMarkerPrefab, hitinfo.point, effectRotation);
            DeliverDamage(hitinfo);
        }
    }

    private void DeliverDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
