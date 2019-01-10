using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    public float damping;
    public Transform[] targets;
    public int targetIndex;
    Vector3 lookPos;
    public int points;

    private Score score;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        // stops the enemies flying
        if (transform.position.y <= -0.44)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        lookPos = targets[targetIndex].position - transform.position;
        lookPos.y = 0;

        //if enemy gets close enough to target, new target is calcualted
        if (Vector3.Distance(gameObject.GetComponentInParent<Transform>().position, targets[targetIndex].position) <= 1f)
        {
            Debug.Log("Close");
            if (targetIndex == targets.Length-1)
            {
                targetIndex = 0;
            }
            else
            {
                targetIndex++;
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(lookPos.normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // destroy enemy and add score if hit into the arena walls
        if (collision.gameObject.name == "Ring")
        {
            Destroy(gameObject.transform.parent.gameObject);
            score.AddScore(points);
        }
    }
}
