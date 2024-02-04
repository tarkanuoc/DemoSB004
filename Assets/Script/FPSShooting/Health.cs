using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public int MaxHP;

    private int _healthPoint;

    private bool IsDead => _healthPoint <= 0;

    private void Start()
    {
        _healthPoint = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        _healthPoint -= damage;

        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Die");
    }

}
