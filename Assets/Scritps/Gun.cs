using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private BulletsPool _bulletsPool;
    [SerializeField] private float _bulletSpeed;

    private void Start()
    {
        _bulletsPool = GetComponent<BulletsPool>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _gameController.IsPathEnded && _gameController.IsGameStarted)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
            PoolObject newBullet = _bulletsPool.GetFreeElement(ray.origin, Quaternion.identity);
            newBullet.GetComponent<Bullet>().ShootBullet(ray.direction);
        }
    }
}
