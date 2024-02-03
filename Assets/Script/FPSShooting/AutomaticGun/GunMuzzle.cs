using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    [SerializeField] private Transform tfmMuzzle;
    public float duration;

    private void Start()
    {
        HideMuzzle();
    }

    public void ShowMuzzle()
    {
        tfmMuzzle.gameObject.SetActive(true);
        float angle = Random.Range(0, 360f);
        tfmMuzzle.localEulerAngles = new Vector3(0, -180f, angle);

        CancelInvoke();
        Invoke(nameof(HideMuzzle), duration);
    }


    private void HideMuzzle()
    {
        tfmMuzzle.gameObject.SetActive(false);
    }
}
