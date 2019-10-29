using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void FixedUpdate() {
        ProcessMovementInput();
    }

    void ProcessMovementInput() {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0) {
            Move(horizontalInput, moveSpeed);
        }
    }

    void Move(float horizontalInput, float moveSpeed) {
        Vector3 moveVector = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(moveVector);
    }
}
