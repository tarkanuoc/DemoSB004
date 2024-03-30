using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private UnityEvent onDie;

    public UnityEvent<int, int> onHealthChanged;
    public int MaxHP;

    private int _healthPoint;

    public int HealthPoint
    {
        get => _healthPoint;
        set
        {
            _healthPoint = value;
            onHealthChanged.Invoke(_healthPoint, MaxHP);
        }

    }

    private bool IsDead => _healthPoint <= 0;

    protected virtual void Start()
    {
        _healthPoint = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        HealthPoint -= damage;
        Debug.Log("========== zombie attacked !");
        if (IsDead)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (anim != null)
        {
            anim.SetTrigger("Die");
        }
        onDie.Invoke();
    }

}
