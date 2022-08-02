using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    void Start()
    {
        foreach (var item in _spawnPoints)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab,item.transform);
            newEnemy.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            newEnemy.transform.SetParent(item);
        }
    }


}
