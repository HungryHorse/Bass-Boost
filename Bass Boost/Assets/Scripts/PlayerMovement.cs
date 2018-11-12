using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float Speed;
    public float maxCharge;
    public float chargeRate;
    public float minCharge;
    public float cooldown;

    public Slider boostMeter;

    private float delayLeft;
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
        
        if (Input.GetButton("Jump") && delayLeft <= 0)
        {
            facing /= 3;
            if(charge <= maxCharge)
            {
                charge += Time.deltaTime * chargeRate;
            }
        }

        if (Input.GetButtonUp("Jump") && delayLeft <= 0)
        {
            boost = true;
            delayLeft = cooldown;
        }

        if (delayLeft > 0)
        {
            delayLeft -= Time.deltaTime;
            charge = 0;
        }

        boostMeter.value = charge;
    }


    void FixedUpdate()
    {
        
        if (boost == true)
        {
            Debug.Log("Boost = true");
            if (charge <= 2)
            {
                player.AddForce(facing.normalized * charge/2 * 500);

                charge = minCharge;

                Debug.Log("Charge is less than 2");
            }
            else
            {
                player.AddForce(facing.normalized * charge * 500);

                charge = minCharge;

                Debug.Log("Charge is more than 2");
            }
            boost = false;
        }
        else
        {
            player.AddForce(facing * Speed);
        }
    }
}
