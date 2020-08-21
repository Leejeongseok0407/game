using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRanger : Bullet
{

    private void Update()
    {
        MoveBullet();
        ReturnBullet();
        LookAtBullet();
    }
    
}
