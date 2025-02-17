using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;

    void Start()
    {
        if(target== null)
        {
            return;
        }
    }

    void Update()
    {
        if(target == null)
            { return; }

        Vector3 pos = transform.position;
    }
}
