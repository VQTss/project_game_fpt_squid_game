using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float speed = 1f;

    private void Update()
    {
        pos = Input.mousePosition;
        pos.z = speed;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
