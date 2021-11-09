using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public static float Speed { set; get; }

    private void Awake()
    {
        Speed = 10f;
    }

  
    void Update()
    {
        transform.position += -Vector3.right * Time.deltaTime * Speed;//лево попрет
    }
}
