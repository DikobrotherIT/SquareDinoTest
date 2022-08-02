using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        Vector3 v = _cam.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(_cam.transform.position - v);
    }
}
