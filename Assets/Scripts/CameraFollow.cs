using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 5.55f;
    public float xOffset = 14.33f;
    private Transform target;

    private void Start()
    {
        target = Player.instance.transform;
    }
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
