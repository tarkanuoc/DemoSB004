using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigibody;

    private bool IsMoveForward;
    private bool IsMoveBack;
    private float _targetRotationY;

    public float WalkSpeedMax;

    private float currentSpeed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            IsMoveForward = true;

            if (currentSpeed < WalkSpeedMax)
            {
                currentSpeed += 0.05f;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            IsMoveForward = false;
            currentSpeed = 0;
        }

        if (IsMoveForward)
        {
            animator.SetBool("IsWalkForward", true);
            var t = currentSpeed / WalkSpeedMax;
            animator.SetFloat("Speed", t);
            WalkForward();
        }
        else
        {
            animator.SetBool("IsWalkForward", false);
            StopMove();
        }

        if (Input.GetKey(KeyCode.S))
        {
            IsMoveForward = false;
            IsMoveBack = true;
            currentSpeed = WalkSpeedMax;
            WalkBack();
            animator.SetBool("IsWalkForward", false);
            animator.SetBool("IsWalkBack", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsWalkBack", false);
            StopMove();
        }



            float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
        _targetRotationY = transform.eulerAngles.y;
    }

    private void WalkForward()
    {
        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.forward;
        rigibody.velocity = targetDirection.normalized * currentSpeed;
    }

    private void WalkBack()
    {
        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.back;
        rigibody.velocity = targetDirection.normalized * currentSpeed;
    }

    private void StopMove()
    {
        rigibody.velocity = Vector3.zero;
    }
}
