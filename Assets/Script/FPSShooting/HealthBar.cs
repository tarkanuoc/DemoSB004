using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imgHealth;

    public void UpdateUI(int currentHP, int maxHP)
    {
        var ratio = (float)currentHP / (float)maxHP;
        imgHealth.fillAmount = ratio;
    }
}
