using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BaseController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertial).normalized;

        //Vector2 mousePosition = Input.mousePosition;
        //Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = this._rigidbody.velocity;

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }   
    }
}
