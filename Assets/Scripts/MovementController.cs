using UnityEngine;

public class MovementController : MonoBehaviour
{

    public Joystick joystick;
    public float moveSpeed;
    private float hInput, vInput;

    private void FixedUpdate() {
        if (joystick == null) return;
        hInput = joystick.Horizontal * moveSpeed;
        vInput = joystick.Vertical * moveSpeed;
        transform.Translate(hInput, vInput, 0);
    }
}
