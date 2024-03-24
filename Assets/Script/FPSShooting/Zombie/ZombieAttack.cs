using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    private Health playerHealth;
    public int damage;

    private void Start()
    {
        playerHealth = Player.Instance.HealthPlayer;
    }

    public void StartAttack()
    {
        anim.SetBool("IsAttacking", true);
        anim.SetBool("IsWalking", false);
    }

    public void StopAttack()
    {
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsWalking", true);
    }

    public void OnAttack(int index)
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);

            if (index == 0)
            {
                PlayerUI.Instance.ShowLeftScratch();
            }
            else
            {
                PlayerUI.Instance.ShowRightScratch();
            }
        }
    }
}
