using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoveByKey : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    public float movingSpeed;
    public float jumpPower = 1f;

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        characterController.SimpleMove(direction * movingSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            transform.DOMoveY(transform.position.y + jumpPower, 0.5f);
        }
    }
}
