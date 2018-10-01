using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform target;
    public float smoothing;
    Vector3 adjustVector = new Vector3(0, 15, -10);
    	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(gameObject.transform.position, target.position + adjustVector, 0.01f * smoothing);
		
	}
}
