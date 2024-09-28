using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  //The position that the camera will be following.
    public float smoothing = 5f;  //The speed with which the camera will be following.

    Vector3 offset;  //The initial offset from the target.

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Create a position the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
