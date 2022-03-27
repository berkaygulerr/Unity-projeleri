using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float scaleSpeed = 1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        InvokeRepeating("SpeedUpScalingTime", 5, 10);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit();
        }
    }

    private static void Hit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit)
        {
            int score = hit.transform.GetComponent<DartScoreManager>().score;

            if (score > 0)
            {
                Debug.Log(score);
            }

            Destroy(hit.transform.parent.gameObject);
        }
    }

    private void SpeedUpScalingTime()
    {
        if (scaleSpeed < 1.5f)
            scaleSpeed += 0.1f;
    }
}
