using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float yPositionKeep = transform.position.y;
        transform.position = new Vector3(Random.Range(-5.23f, 3.7f),yPositionKeep, Random.Range(-3.281f, 4.76f));
    }

}
