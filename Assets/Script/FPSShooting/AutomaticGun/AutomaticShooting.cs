using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class AutomaticShooting : Shooting
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private Camera aimingCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent onShoot;
    [SerializeField] private GunAmmo ammo;

    public int rpm;
    public AudioSource shootSound;

    private float lastShot;
    private float interval;


    void Start()
    {
        interval = 60f / rpm;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    private void Shoot()
    {
        anim.Play("Shoot");
        shootSound.Play();
        PerformRaycasting();

       // var randomY = Random.Range(10, 100f);

       // aimingCamera.transform.DOShakeRotation(0.1f, 90f, 10, 90);
     
        ammo.LoadedAmmo--;
        onShoot.Invoke();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, -transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitinfo, 1000f, layerMask))
        {
            var effectRotation = Quaternion.LookRotation(hitinfo.normal);
            Instantiate(hitMarkerPrefab, hitinfo.point, effectRotation);
        }
    }
}
