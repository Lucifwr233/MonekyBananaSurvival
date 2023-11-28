using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 5.55f;
    public float xOffset = 14.33f;
    public Transform target;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, - 10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
