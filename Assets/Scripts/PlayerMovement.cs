using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed;
    private Rigidbody rb;
    public float forward;
    public float side;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
        //Getting component
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting key inputs
        forward = Input.GetAxis("Vertical") * speed;
        side = Input.GetAxis("Horizontal") * speed;

    }
    //moves the player to the direction of the camera
    public void FixedUpdate()
    {
        rb.velocity = (transform.forward * forward) + (transform.right * side);
    }

}
