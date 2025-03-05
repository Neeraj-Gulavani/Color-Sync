using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float targetSpeed=100f;
    public float force=500f;
    public float currentSpeed,sideSpeed=5f;
    public TMP_Text scoreText;
    public static int score=0;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        int a = (int)(transform.position.z * 0.1f);
        if (a<score) {

        } else {
        score = a;
        if (score<0) {
            score=0;
        }
        scoreText.text = score.ToString();
        }
    }
    void FixedUpdate()
    {
        ForwardMovement();
        SideMovement();
        rb.AddForce(Vector3.down * 5f, ForceMode.Acceleration);
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
