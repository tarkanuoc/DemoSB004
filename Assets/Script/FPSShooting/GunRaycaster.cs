using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    private GameObject hitMarkerPrefab;
  //  [SerializeField] private HitEffectManager hitEffectManager;
    [SerializeField] private Camera aimingCamera;
    [SerializeField] private LayerMask layerMask;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, -transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitinfo, 1000f, layerMask))
        {
            var effectRotation = Quaternion.LookRotation(hitinfo.normal);
            var hitSurface = hitinfo.collider.GetComponent<HitSurface>();

            if (hitSurface != null)
            {
                //hitMarkerPrefab = hitEffectManager.effectMap[(int)hitSurface.surfaceType].effectPrefab;
                hitMarkerPrefab = HitEffectManager.Instance.effectMap[(int)hitSurface.surfaceType].effectPrefab;
            }
            Instantiate(hitMarkerPrefab, hitinfo.point, effectRotation);
            DeliverDamage(hitinfo);
        }
    }

    private void DeliverDamage(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.GetComponentInParent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
