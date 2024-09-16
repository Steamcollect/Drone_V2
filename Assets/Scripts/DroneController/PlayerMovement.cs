using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Statitics")]
    [SerializeField] float moveSpeed;

    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerMotor motor;
    [SerializeField] Camera cam;

    private void FixedUpdate()
    {
        MoveHorizontaly();
    }

    void MoveHorizontaly()
    {
        Vector3 direction = motor.GetInputs().normalized;

        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + (cam.transform.eulerAngles.y);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.AddForce(moveDir.normalized * moveSpeed);
        }        
    }
}