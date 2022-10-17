using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform = null;

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransform == null) return;
        transform.position = playerTransform.position;
    }
}
