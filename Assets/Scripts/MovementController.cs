using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public Joystick joystick;
    public float moveSpeed;
    private float hInput, vInput;
    private Animator animator;
    private int direction;
    private float lastAnimationUpdateTime;

    private void Start() {
        animator = GetComponent<Animator>();
        lastAnimationUpdateTime = Time.time;
    }

    // private void FixedUpdate() {
    //     if (joystick == null) return;
    //     hInput = joystick.Horizontal * moveSpeed;
    //     vInput = joystick.Vertical * moveSpeed;
    //     if (Math.Abs(hInput) > Math.Abs(vInput))  direction = hInput > 0 ? 2 : 3;
    //     else direction = vInput > 0 ? 1 : 0;
    //     animator.SetInteger("Direction", direction);
    //     transform.Translate(hInput, vInput, 0);
    // }



    private void FixedUpdate() {
        if (joystick == null) return;

        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        int direction = GetMovementDirection(input);
        Vector3 move = transform.position + moveSpeed * (Vector3)input;
        transform.position = Vector3.Lerp(transform.position, move, 0.1f);

        if (Time.time - lastAnimationUpdateTime > 0.1f) {
            animator.SetInteger("Direction", direction);
            lastAnimationUpdateTime = Time.time;
        }
    }

    private int GetMovementDirection(Vector2 input) {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
            return input.x > 0 ? 2 : 3;
        } else {
            return input.y > 0 ? 1 : 0;
        }
    }

}
