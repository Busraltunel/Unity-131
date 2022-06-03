using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACamera : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        transform.rotation = target.rotation;
        transform.position = target.position;
    }
}