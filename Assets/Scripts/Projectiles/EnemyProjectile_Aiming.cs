using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile_Aiming : Projectile
{
    void Awake() 
    {
        SetTarget(GameObject.FindGameObjectWithTag("Player"));
    }

    protected override void OnEnable() 
    {
        StartCoroutine(nameof(MoveDirectionCoroutine));
        base.OnEnable();
        // if (target == null) base.OnEnable();
        // else StartCoroutine(guidanceSystem.HomingCoroutine(target));
    }

    IEnumerator MoveDirectionCoroutine()
    {
        yield return null;

        if (target.activeSelf) moveDirection = (target.transform.position - transform.position).normalized;
    }
}
