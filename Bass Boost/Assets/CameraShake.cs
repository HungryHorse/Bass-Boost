using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float time = 0.0f;

        while (time <= duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            time += Time.deltaTime;

            if(Time.timeScale <= 0)
            {
                time = duration;
            }

            yield return null;
        }

        transform.localPosition = originalPos;

        if(transform.localPosition != new Vector3(0, 0, 0))
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
