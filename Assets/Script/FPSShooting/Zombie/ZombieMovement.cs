using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    private Transform _target;
    private bool _isMovingValue;

    public Transform ZombieTargetMove
    {
        get => _target;
        set
        {
            _target = value;
        }
    }

    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value)
                return;
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

    public void UpdateMovement()
    {
        if (_target != null)
        {
            var distance = Vector3.Distance(transform.position, _target.position);
            IsMoving = distance > reachingRadius;

            if (IsMoving)
            {
                agent.SetDestination(_target.position);
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, _target.eulerAngles.y + 180f, transform.eulerAngles.z);
        }
    }

    public void OnZombieDie()
    {
        enabled = false;
        agent.isStopped = true;
    }

}
