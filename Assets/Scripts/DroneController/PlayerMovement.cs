using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Statitics")]
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;

    [Header("References")]
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerMotor motor;
    [SerializeField] Camera cam;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 horizontalInput = motor.GetHorizontalInputs().normalized;
        float verticalInput = motor.GetVerticalInput();

        Vector3 horizontalDir = Vector3.zero;
        Vector3 verticalDir = Vector3.zero;

        // Horizontal
        if (horizontalInput.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(horizontalInput.x, horizontalInput.z) * Mathf.Rad2Deg + (cam.transform.eulerAngles.y);
            horizontalDir = (Quaternion.Euler(0, targetAngle, 0) * Vector3.forward).normalized * horizontalSpeed;
        }
        // Vertical
        if(verticalInput != 0)
        {
            verticalDir = Vector3.up * motor.GetVerticalInput() * verticalSpeed;
        }

        rb.AddForce(horizontalDir + verticalDir);

    }
}