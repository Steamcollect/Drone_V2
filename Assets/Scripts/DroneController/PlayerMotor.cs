using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public Vector3 GetHorizontalInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        return new Vector3(x, 0, z);
    }

    public float GetVerticalInput()
    {
        float y = 0;
        if (Input.GetKey(KeyCode.Space)) y = 1;
        else if (Input.GetKey(KeyCode.LeftShift)) y = -1;

        return y;
    }
}