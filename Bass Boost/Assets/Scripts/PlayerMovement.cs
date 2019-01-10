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
    public float boostPad;
    public bool onBeat;
    public bool framePaddedBoost;
    public Light blue;
    public Light green;
    public Light red;
    public Shader boostShader;
    public CameraShake cameraShake;
    public AudioSource boostSound;

    public Slider boostMeter;

    private float currSpeed;
    private float boostPadding;
    private float frameCount;
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
        currSpeed = Speed;

        if (onBeat)
        {
            framePaddedBoost = true;
            boostPadding = boostPad;
        }

        if(red.color != Color.red && frameCount <= 0)
        {
            red.color = Color.red;
            blue.color = Color.blue;
            green.color = Color.green;
        }
        else if(frameCount > 0)
        {
            frameCount -= Time.deltaTime;
        }

        if(boostPadding > 0)
        {
            boostPadding -= Time.deltaTime;
        }
        else if(boostPadding <= 0)
        {
            framePaddedBoost = false;
        }


        if (delayLeft > 0)
        {
            delayLeft -= Time.deltaTime;
            charge = 0;
        }

        facing = Vector3.zero;
        facing.x = Input.GetAxis("Horizontal");
        facing.z = Input.GetAxis("Vertical");

        //if (facing != Vector3.zero)
        //{
        //    facing = new Vector3(facing.x, 0, facing.z);
        //}
        
        if (Input.GetButton("Jump") && delayLeft <= 0)
        {
            currSpeed /= 3;
            if(charge <= maxCharge)
            {
                charge += Time.deltaTime * chargeRate;
            }
        }

        if (framePaddedBoost)
        {
            body.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonUp("Jump") && delayLeft <= 0)
        {
            boost = true;
            boostSound.Play();
            delayLeft = cooldown;
            if (framePaddedBoost)
            {
                charge *= 2;
                red.color = Color.yellow;
                red.intensity = 2;
                blue.color = Color.yellow;
                blue.intensity = 2;
                green.color = Color.yellow;
                green.intensity = 2;
                frameCount = 0.3f;
            }
            
            if (charge <= 2)
            {
                player.AddForce(facing.normalized * charge / 2 * 500);

                charge = minCharge;
            }
            else
            {
                player.AddForce(facing.normalized * charge * 500);

                charge = minCharge;
            }
            boost = false;
        }
        
        boostMeter.value = charge;
    }


    void FixedUpdate()
    {
        player.AddForce(facing * currSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            StartCoroutine(cameraShake.Shake(0.3f, player.velocity.magnitude/10));
        }
    }
}
