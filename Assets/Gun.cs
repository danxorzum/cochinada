using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Transform canon;
    public override void Hit()
    {
        base.Hit();
        if(Physics.Raycast(canon.transform.position,canon.forward,out var hit, 500f))
        {
            hit.collider.gameObject.SendMessage(modi)
        }

    }
}
