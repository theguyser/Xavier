using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarYMotion : MonoBehaviour
{
    public float amplitude = 0.05f;
    public float frequency = 1f;
    float originalY;
    public float noiseoffset = 0.05f;

    void Start()
    {
        originalY = transform.position.y-0.5f;
        //noiseoffset = Random.Range(0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        float newY = originalY + amplitude * Mathf.Sin(Time.time) + Mathf.PerlinNoise(noiseoffset, Time.time*frequency);
        float onlyNoise = originalY + Mathf.PerlinNoise(noiseoffset, Time.time * frequency);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        
    }
}
