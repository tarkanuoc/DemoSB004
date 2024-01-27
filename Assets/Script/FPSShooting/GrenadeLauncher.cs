using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform tfmFiringPos;
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private GunAmmo ammo;
    public float bulletSpeed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        animator.SetTrigger("Shoot");
    }

    public void PlayFireSound()
    {
        fireSound.Play();
    }

    public void AddProjectile()
    {
        var bullet = Instantiate(bulletPrefab, tfmFiringPos.position, tfmFiringPos.rotation);
        var bulletRigibody = bullet.GetComponent<Rigidbody>();
        bulletRigibody.velocity = tfmFiringPos.forward * bulletSpeed;
        ammo.LoadedAmmo--;
    }
}
