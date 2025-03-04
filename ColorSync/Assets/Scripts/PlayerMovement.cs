using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float targetSpeed=100f;
    public float force=500f;
    public float currentSpeed,sideSpeed=5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ForwardMovement();
        SideMovement();
    }

    void ForwardMovement() {
        currentSpeed = rb.velocity.z;
        if (currentSpeed<targetSpeed) {
            rb.AddForce(Vector3.forward * force * Time.fixedDeltaTime,ForceMode.Force);
        }
        if (currentSpeed>targetSpeed) {
            Vector3 clampedVel = rb.velocity;
            clampedVel.z = targetSpeed;
            rb.velocity = clampedVel;
        }
    }

    void SideMovement() {
        float horInp = Input.GetAxis("Horizontal");
        Vector3 sideMove = Vector3.right * horInp * sideSpeed;
        rb.velocity = new Vector3(sideMove.x, rb.velocity.y, rb.velocity.z);
    }
}
