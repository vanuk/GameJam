using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform viewObject;
    void LateUpdate()
    {
        if (viewObject)
        {
            var pos = viewObject.position;
            transform.position = new Vector3(pos.x, pos.y + 0.5f, transform.position.z);
        }
    }
}
