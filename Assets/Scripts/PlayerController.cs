using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpSpeed;

    [SerializeField]
    Rigidbody rb;

    bool isGrounded;

    void Start() {
        isGrounded = false;
    }

    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            isGrounded = false;
            movement.y = jumpSpeed;
            rb.AddForce(movement);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.gameObject.name == "Floor") {
            isGrounded = true;
        } 
    }
}