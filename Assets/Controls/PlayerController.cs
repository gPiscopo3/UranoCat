using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;
    protected CharacterStatus status;

    private void Awake()
    {
       characterController = GetComponent<CharacterController>(); 
       status = GetComponent<CharacterStatus>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        if (status.IsMoving)
        {
            movement.z = status.Movement.z*Time.deltaTime;
            movement.x = status.Movement.x*Time.deltaTime;
        }
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
    }

}
