using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public Vector2 rotateRange = new Vector2(-3f, 3f);
    public float Delata = 3f;
    public float delay = 6f;
    public float TargetRotation = 15f;

    private float rot;
    private bool r;
    private float targetrotation;
    void Start()
    {
        StartCoroutine(nameof(Rotetion));
    }
    IEnumerator Rot()
    {
        float t = 0f;
        yield return new WaitForSeconds(delay);
        while (t < 2)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetrotation), 0.05f);

            t += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    IEnumerator Rotetion()
    {
        while (true)
        {
            targetrotation = TargetRotation;
            yield return StartCoroutine(nameof(Rot));

            targetrotation = 0f;
            yield return StartCoroutine(nameof(Rot));

            targetrotation = -TargetRotation;
            yield return StartCoroutine(nameof(Rot));

            targetrotation = 0f;
            yield return StartCoroutine(nameof(Rot));
        }
    }
}
