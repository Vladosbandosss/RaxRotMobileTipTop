using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false);
            ObstacleGenerator.Obstacles.Enqueue(collision.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
