using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float time = 0.8f;
    public GameObject dartPref;

    private void Start()
    {
        InvokeRepeating("SpeedUpTime", 5, 10);
    }

    private void FixedUpdate()
    {
        StartCoroutine(SpawnDart());
    }

    IEnumerator SpawnDart()
    {
        yield return new WaitForSeconds(time);

        float randomX = Random.Range(-7f, 7f);
        float randomY = Random.Range(-3f, 3f);
        Vector2 vec = new Vector2(randomX, randomY);

        Instantiate(dartPref, vec, Quaternion.identity);

        StopAllCoroutines();
    }

    private void SpeedUpTime()
    {
        if (time > 0.4f)
            time -= 0.1f;
    }
}
