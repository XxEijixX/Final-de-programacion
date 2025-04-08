using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    [SerializeField]
    private float sensX;
    [SerializeField]
    private float sensY;

    private Transform charCtrl;

    private float xRot = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        charCtrl = transform.parent;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        charCtrl.Rotate(Vector3.up * mouseX);

        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
