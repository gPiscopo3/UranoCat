using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] protected float walkSpeed = 5.0f;

    protected bool isMoving; // whether the character is moving
    protected Vector3 movement; //movement speed

    public bool IsMoving
    {
        get { return isMoving; }
    }   

    public Vector3 Movement
    {
        get { return movement; }
    }

    void Update()
    {
        isMoving = movement.z != 0 || movement.x != 0;
    }
    public void OnMove(InputValue value){
        Vector3 inputs = value.Get<Vector3>();
        Debug.Log(inputs);
        movement.z = inputs.y*walkSpeed;
        movement.x = (inputs.x*walkSpeed)/2;
    }

}
