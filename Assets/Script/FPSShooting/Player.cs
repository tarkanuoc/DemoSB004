using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Transform playerFoot;
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private Health healthPlayer;

    public Transform PlayerFoot => playerFoot;
    public PlayerUI PlayerUI => playerUI;
    public Health HealthPlayer => healthPlayer;
}
