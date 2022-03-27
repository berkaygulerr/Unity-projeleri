using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    private float scalingTime = 0.5f;

    private void Start()
    {
        transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);

        if (transform.localScale.x > 1f)
            scalingTime = 0.9f;
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = scale.y -= scalingTime * GameManager.instance.scaleSpeed * Time.deltaTime;

        transform.localScale = scale;

        if (transform.localScale.x <= 0)
            Destroy(gameObject);
    }

    private void SpeedUpScalingTime()
    {
        scalingTime += 0.1f;
    }
}
