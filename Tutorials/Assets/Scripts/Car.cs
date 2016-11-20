using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    private float currentAccel;
    public float acceleration;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            currentAccel = acceleration;
        }
        else
        {
            currentAccel = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, transform.up, -5);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, transform.up, 5);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * currentAccel, ForceMode.Acceleration);
    }
}
