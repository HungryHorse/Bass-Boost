using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float Speed;
    public float maxCharge;
    public float chargeRate ;
    public float minCharge;

    public Slider boostMeter;

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
        }

        boostMeter.value = charge;
    }


    void FixedUpdate()
    {
        
        if (boost == true)
        {
            player.AddForce(facing.normalized * charge * 200);
            
            charge = minCharge;
            boost = false;
        }
        else
        {
            player.AddForce(facing * Speed);
        }
    }
}
