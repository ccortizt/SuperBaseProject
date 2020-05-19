using System;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] float speedMetersPerSecond = 1f;

    private Vector3? destination;
    private Vector3 startPosition;
    private float totalLerpDuration;
    private float elapsedLerpDuration;
    private Action onCopleteCallBack;


    void Update()
    {
        if (destination.HasValue == false)
        {
            return;
        }

        if (elapsedLerpDuration >= totalLerpDuration && totalLerpDuration > 0)
        {
            return;
        }

        elapsedLerpDuration += Time.deltaTime;
        float percent = elapsedLerpDuration / totalLerpDuration;

        transform.position = Vector3.Lerp(startPosition, destination.Value, percent);

        if (elapsedLerpDuration >= totalLerpDuration)
        {
            onCopleteCallBack.Invoke();
        }

    }


    public void MoveTo(Vector3 destination, Action onComplete = null)
    {
        var distanceToNextWayPoint = Vector3.Distance(transform.position, destination);
        totalLerpDuration = distanceToNextWayPoint / speedMetersPerSecond;

        startPosition = transform.position;
        elapsedLerpDuration = 0;
        this.destination = destination;
        onCopleteCallBack = onComplete;

    }
}
