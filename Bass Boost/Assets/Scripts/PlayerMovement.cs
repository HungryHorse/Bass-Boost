using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed = 5f;

    private Rigidbody player;
    private Vector3 facing;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        facing = Vector3.zero;
        facing.x = Input.GetAxis("Horizontal");
        Debug.Log(Input.GetAxis("Horizontal"));
        facing.z = Input.GetAxis("Vertical");
        if (facing != Vector3.zero)
        {
            transform.forward = facing;
        }

        if (Input.GetButtonDown("Jump"))
        {
            facing *= 2;
        }

    }


    void FixedUpdate()
    {
        player.MovePosition(player.position + facing * Speed * Time.fixedDeltaTime);
    }
}
