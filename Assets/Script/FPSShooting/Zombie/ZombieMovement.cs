using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Transform playerFoot;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    private bool _isMovingValue;

    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value) return;
            _isMovingValue = value;
            OnIsMovingValueChanged();
        }
    }

    private void OnIsMovingValueChanged()
    {
        agent.isStopped = !_isMovingValue;
        anim.SetBool("IsWalking", _isMovingValue);
        if (_isMovingValue)
        {
            onStartMoving.Invoke();
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }


    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, playerFoot.position);
        IsMoving = distance > reachingRadius;

        if (IsMoving)
        {
            agent.SetDestination(playerFoot.position);
        }
        
    }
}
