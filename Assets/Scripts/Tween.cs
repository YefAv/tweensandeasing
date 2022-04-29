using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField]
    float duration = 1;

    [SerializeField]
    private Transform targetPos ;

     private float t = 0;

    private bool isPlaying = false;
    private float accumulatedTime = 0;
    private Vector3 startPosition;

    [SerializeField]
    private AnimationCurve ease;

    void Start()
    {
        Debug.Assert(targetPos != null, "target is null");
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            accumulatedTime = 0;
            isPlaying = true;
            startPosition = transform.position;
        }

        if (!isPlaying) return;
        float t = accumulatedTime / duration;
        transform.position = Vector3.LerpUnclamped(startPosition, targetPos.position, ease.Evaluate(t));
        accumulatedTime += Time.deltaTime;

        if (t>=1)
        {
            isPlaying = false;
            Debug.Log("completed");
        }
    }


    private float cubic(float x) {
        return x * x * x;
    }
}
