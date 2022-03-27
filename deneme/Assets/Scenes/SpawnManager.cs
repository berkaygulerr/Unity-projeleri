using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private Vector2 spawnPos;
    void Start()
    {
        spawnPos = Vector2.zero;
        Shoot();
    }

    private float time;
    private float spawnTime = 1;
    private float repeatTime = 1;
    void Update()
    {
        time += Time.deltaTime;

        if (time > spawnTime)
        {
            Shoot();
            spawnTime = time + repeatTime;
        }
    }
    
    public void Shoot()
    {
        Instantiate(bullet, spawnPos, quaternion.identity);
    }
}
