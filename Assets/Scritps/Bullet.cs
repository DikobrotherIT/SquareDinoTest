using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    private PoolObject _poolObject;
    private Vector3 _direction;
    private void Start()
    {
        _poolObject = this.GetComponent<PoolObject>();
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(_direction * _bulletSpeed);
    }

    public void ShootBullet(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_bulletLifeTime);
        _poolObject.ReturnToPool();
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.GettingDamage(_bulletDamage);
        }
        _poolObject.ReturnToPool();
    }
}
