﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullit : MonoBehaviour
{
        public Vector3 targetPosition = Vector3.zero;
        public GameObject ExplosionParticle = null;
       
        void Update()
        {
        AttackBullit();
        }

    void AttackBullit() {
        transform.Translate(targetPosition * Time.deltaTime * 3.0f);

        // 나와 부모의 사이가 일정거리(1.5f) 도달하면 삭제
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 1.5f)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -0.64f || transform.position.x > 13.44f || transform.position.y < -0.64f || transform.position.y > 8.32f)
        {
            Destroy(gameObject);
        }
    }

}
