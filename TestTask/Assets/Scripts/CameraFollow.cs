using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform LookAt;
    private Vector3
        _offset,
        _cameraMove;

    void Start()
    {
        _offset = transform.position - LookAt.position;
    }
    void Update()
    {
        CameraInGamePosition();
    }

    private void CameraInGamePosition()
    {
        _cameraMove = LookAt.position + _offset;
        transform.position = _cameraMove;
    }
}
