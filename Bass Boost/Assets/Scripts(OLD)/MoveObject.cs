using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    public float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update () {

        rb.AddForce(transform.forward * speed);
	}
}
