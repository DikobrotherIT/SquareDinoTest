using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    private NavMeshAgent _playerNavAgent;
    private int _currentWayPoint = 0;

    public int CurrentWayPoint => _currentWayPoint;
    public int MaxWayPoints => _wayPoints.Count;


    private void Awake()
    {
        _playerNavAgent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
    }

    public void GoToNextWayPoint()
    {
        if(_currentWayPoint < _wayPoints.Count)
        {
            _playerNavAgent.SetDestination(_wayPoints[_currentWayPoint].position);
            _currentWayPoint++;
        }
    }

}
