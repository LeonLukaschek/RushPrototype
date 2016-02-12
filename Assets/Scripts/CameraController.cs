using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(2.5f, 4, -5));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}