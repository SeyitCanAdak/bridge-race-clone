using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour
{   
    public float rotationSpeed;
    void Update()
    {
        transform.Rotate(0, rotationSpeed,0);
    }
}
