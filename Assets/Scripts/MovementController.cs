using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public Joystick joystick;
    public float moveSpeed;
    private float hInput, vInput;


    private void FixedUpdate() {
        Debug.Log(joystick, this);
        if (joystick == null) {
            Debug.Log("No existe", this);
            return;
                }
        Debug.Log("Si existe", this);
        hInput = joystick.Horizontal * moveSpeed;
        Debug.Log(hInput, this);
        vInput = joystick.Vertical * moveSpeed;
        Debug.Log(vInput, this);
        transform.Translate(hInput, vInput, 0);
    }
}
