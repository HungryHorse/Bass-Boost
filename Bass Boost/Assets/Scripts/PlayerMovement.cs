using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public GameObject body;
    public float Speed;
    public float maxCharge;
    public float chargeRate;
    public float minCharge;
    public float cooldown;
    public bool onBeat;

    public Slider boostMeter;

    private float delayLeft;
    private bool boost = false;
    private float charge;
    private Rigidbody player;
    private Vector3 facing;
    private Vector3 DashForce;
    private Camera cameraMain;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        charge = minCharge;
        cameraMain = Camera.main;
    }

    void Update()
    {

        if (delayLeft > 0)
        {
            delayLeft -= Time.deltaTime;
            charge = 0;
        }

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
            if (onBeat)
            {
                charge *= 2;
            }
            
            Debug.Log("Boost = true");
            Debug.Log(charge);
            if (charge <= 2)
            {
                player.AddForce(facing.normalized * charge / 2 * 500);

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

        if (onBeat)
        {
            body.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        boostMeter.value = charge;
    }


    void FixedUpdate()
    {

        player.AddForce(facing * Speed);
    }
}
