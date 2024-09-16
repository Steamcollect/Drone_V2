using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] float distance;
    [SerializeField] float sensitivity;

    [SerializeField] Vector3 posOffset;

    [SerializeField] Vector2 minMaxY;

    float currentX, currentY;

    [Header("References")]
    [SerializeField] Transform target;

    private void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, minMaxY.x, minMaxY.y);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = (target.position + posOffset) + rotation * Direction;

        transform.LookAt(target.position + posOffset);
    }

    public void SetTarget(Transform target) => this.target = target;
}