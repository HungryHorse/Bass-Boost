using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float Speed = 5f;
    public float maxCharge = 5f;
    public float chargeRate = 0.25f;
    public float minCharge = 2f;

    private bool boost = false;
    private float charge;
    private Rigidbody player;
    private Vector3 facing;
    private Vector3 DashForce;


    void Start()
    {
        player = GetComponent<Rigidbody>();
        charge = minCharge;
    }

    void Update()
    {
        
        facing = Vector3.zero;
        facing.x = Input.GetAxis("Horizontal");
        facing.z = Input.GetAxis("Vertical");
        if (facing != Vector3.zero)
        {
            facing = new Vector3(facing.x, 0, facing.z);
        }
        
        if (Input.GetButton("Jump"))
        {
            facing /= 3;
            if(charge <= maxCharge)
            {
                charge += Time.deltaTime * chargeRate;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            boost = true;
            charge = minCharge;
        }

    }


    void FixedUpdate()
    {
        
        if (boost == true)
        {
            Debug.Log("Boost");
            player.AddForce( * charge * 10);
            boost = false;
        }
        else
        {
            player.AddForce(facing * Speed);
        }
    }
}
