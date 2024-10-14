using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    [SerializeField] public float sens = 1.0f;
    [SerializeField] private Transform player;

    private CameraControls cameraControls;
    private Vector2 lookInput;
    private bool isLooking;

    float xRotation;
    float yRotation;

    private void Awake()
    {
        cameraControls = new CameraControls();
    }

    private void OnEnable()
    {
        cameraControls.Camera.Look.performed += onLookPerformed;
        cameraControls.Camera.Look.canceled += OnLookCanceled;
        cameraControls.Camera.Look.Enable();
    }

    private void OnDisable()
    {
        cameraControls.Camera.Look.Disable();
    }

    private void onLookPerformed(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        float mouseX = lookInput.x * sens * Time.deltaTime;
        float mouseY = lookInput.y * sens * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void OnLookCanceled(InputAction.CallbackContext context)
    {
        // Quando l'input del mouse si ferma, fermiamo la rotazione
        isLooking = false;
    }

}
