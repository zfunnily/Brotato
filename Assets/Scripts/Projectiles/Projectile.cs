using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject hitVFX;
    [SerializeField] AudioData[] hitSFX;
    [SerializeField] float damage;
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 moveDirection;
    protected GameObject target;

    protected virtual void OnEnable() 
    {
        StartCoroutine(MoveDirectly());
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.TryGetComponent<Character>(out Character character)) 
        {
            character.TakeDamage(damage);

            // var contackPoint = collision.GetContact(0);
            // PoolManager.Release(hitVFX, collision.GetContact(0).point, Quaternion.LookRotation(collision.GetContact(0).normal));

            // AudioManager.Instance.PlayRandomSFX(hitSFX);

            gameObject.SetActive(false);
        }
    }

    IEnumerator MoveDirectly()
    {
        while (gameObject.activeSelf)
        {
            Move();
            
            yield return null;
        }
    }

    protected void SetTarget(GameObject target) => this.target = target;
    public void Move() => transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
}
