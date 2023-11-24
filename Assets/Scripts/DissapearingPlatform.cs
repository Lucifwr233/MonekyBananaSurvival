using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearingPlatform : MonoBehaviour
{
    [SerializeField]
    private float disappearTime = 2f; // Waktu ketika platform menghilang

    private Renderer platformRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        InvokeRepeating("ToggleVisibility", disappearTime, disappearTime);
    }

    private void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}