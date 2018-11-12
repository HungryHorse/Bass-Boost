using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDir : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            gameObject.transform.LookAt(gameObject.transform.position + new Vector3(Input.GetAxis("Horizontal"), 1, Input.GetAxis("Vertical")));
        }
        gameObject.transform.eulerAngles = new Vector3(-90, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
    }
}
