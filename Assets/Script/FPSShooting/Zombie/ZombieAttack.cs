using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private ZombieSO ZombieSO;
    [SerializeField] private Animator anim;
    
    private Health playerHealth;
    

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
            playerHealth.TakeDamage(ZombieSO.Damage);

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
