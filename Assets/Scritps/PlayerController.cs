using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private NavMeshAgent _agent;
    private Animator _playerAnimator;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (_agent.hasPath == true && _gameController.IsGameStarted)
        {
            _gameController.ChangePathStatus(false);
            _playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            _gameController.ChangePathStatus(true);
            _playerAnimator.SetBool("isRunning", false);
        }
    }
}
