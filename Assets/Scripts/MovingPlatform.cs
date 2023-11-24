using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f; // Kecepatan gerakan platform

    [SerializeField]
    private float moveDistance = 5f; // Jarak total yang akan ditempuh platform

    private Vector3 initialPosition;
    private float direction = 1; // 1 untuk gerakan ke kanan, -1 untuk gerakan ke kiri

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        // Hitung perpindahan platform
        float displacement = moveSpeed * Time.deltaTime * direction;

        // Pindahkan platform
        transform.Translate(new Vector3(displacement, 0, 0));

        // Periksa apakah platform telah mencapai batas jarak
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= moveDistance / 2)
        {
            // Ubah arah pergerakan
            direction *= -1;
        }
    }
}
