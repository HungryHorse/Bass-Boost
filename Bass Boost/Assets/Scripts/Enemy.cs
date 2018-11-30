using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    public float damping;
    public Transform target;
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
        if (transform.position.y <= -0.44)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        lookPos = target.position - transform.position;
        lookPos.y = 0; 
    }

    void FixedUpdate()
    {
        rb.AddForce(lookPos.normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ring")
        {
            Destroy(gameObject.transform.parent.gameObject);
            score.AddScore(points);
        }
    }
}
