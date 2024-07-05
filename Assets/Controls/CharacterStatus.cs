using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField] protected float walkSpeed = 5.0f;
    [SerializeField] protected float rotationSensitivity = 5.0f;

    protected bool isMoving; // whether the character is moving
    protected bool isRotating; //whether the character is rotating
    protected Vector3 movement; //movement speed
    protected Vector3 rotation; //rotation speed

    public bool IsMoving
    {
        get { return isMoving; }
    }   

    public bool IsRotating
    {
        get { return isRotating; }
    }
    public Vector3 Movement
    {
        get { return movement; }
    }
    public Vector3 Rotation
    {
        get { return rotation; }
    }
    void Update()
    {
        isMoving = movement.z != 0;
        isRotating = rotation.y != 0;
    }
    public void OnMove(InputValue value){
        Vector3 inputs = value.Get<Vector3>();
        movement.z = inputs.y*walkSpeed;
        rotation.y = inputs.x*rotationSensitivity;
    }
}
