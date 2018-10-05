using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform target;
    public float smoothing;
    public float x, y, z;
    Vector3 adjustVector;

    private void Start()
    {
        adjustVector = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void LateUpdate () {

        transform.position = Vector3.Lerp(gameObject.transform.position, target.position + adjustVector, 0.01f * smoothing);
		
	}
}
