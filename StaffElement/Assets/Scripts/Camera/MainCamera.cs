using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - followTarget.position;    
    }

    private void LateUpdate()
    {
        transform.position = offset + followTarget.position;
    }
}
