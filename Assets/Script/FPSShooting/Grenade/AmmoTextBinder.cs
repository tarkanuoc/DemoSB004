using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextBinder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadedAmmoText;
    [SerializeField] private GunAmmo gunAmmo;

    private void Start()
    {
       // gunAmmo.loadedAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();
    }

    public void UpdateGunAmmo()
    {
        loadedAmmoText.text = gunAmmo.LoadedAmmo.ToString();
    }
}
