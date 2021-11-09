using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public static Queue<GameObject> Obstacles;

    public int poolSize = 50;
    public float speed = 10f;
    public float smooth = 5f;

    public Vector2 WidthRange = new Vector2(3f, 3f);
    public Vector2 HightRange = new Vector2(2.3f, 4.3f);

    public Transform obstacleContainer;
    public GameObject obstacle;

    private Vector3 startPos;

    private GameObject top;
    private GameObject bottom;

    private float topHeight;
    private float topWidth;

    private float bottomHeight;
    private float bottomWidth;

    private float topInterval
    {
        get => (topWidth - smooth / speed) / speed;//типо return эту хрень
    }

    private float bottomInterval
    {
        get => (bottomWidth - smooth / speed) / speed;
    }

    private Vector3 topScale
    {
        get => new Vector3(topWidth, topHeight, 1);
    }

    private Vector3 bottomScale
    {
        get => new Vector3(bottomWidth, bottomHeight, 1);
    }

    private void Awake()
    {
        startPos = new Vector3(15f, 0f, 0f);
        FillPool();
    }

    private void Start()
    {
        StartCoroutine(nameof(TopRandomGen));
        StartCoroutine(nameof(BottomRandomGen));
    }

    private void FillPool()
    {
        Obstacles = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject clone = Instantiate(obstacle, startPos, Quaternion.identity, obstacleContainer);
            clone.SetActive(false);
            Obstacles.Enqueue(clone);
        }
    }

    private void UpdateSpeed()
    {
        ObstacleMover.Speed = speed;
    }

    private GameObject GetObstacles()
    {
        GameObject clone = Obstacles.Dequeue();
        clone.transform.position = startPos;
        UpdateSpeed();
        return clone;
    }

    void UpdateTopTransform()
    {
        top.transform.localScale = topScale;
        top.transform.position = new Vector3(top.transform.position.x, 5 - top.transform.localScale.y / 2f, 0);
    }

    void UpdateBottomTransform()
    {
        bottom.transform.localScale = bottomScale;
        bottom.transform.position = new Vector3(bottom.transform.position.x, -5 + bottom.transform.localScale.y / 2f, 0);
    }

    private IEnumerator TopRandomGen()
    {
        topWidth = WidthRange.x;

        while (true)
        {
            top = GetObstacles();
            topHeight = UnityEngine.Random.Range(HightRange.x, HightRange.y);
            UpdateTopTransform();
            yield return new WaitForSeconds(topInterval);
            top.SetActive(true);
        }
    }

    private IEnumerator BottomRandomGen()
    {
        bottomWidth = WidthRange.x;

        while (true)
        {
            bottom = GetObstacles();
            bottomHeight = UnityEngine.Random.Range(HightRange.x, HightRange.y);
            UpdateBottomTransform();
            yield return new WaitForSeconds(bottomInterval);
            bottom.SetActive(true);
        }
    }
}
