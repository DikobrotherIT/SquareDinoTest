using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool _isGameStarted = false;
    [SerializeField] private bool _isPathEnded = false;
    [SerializeField] private Animator _victoryFemale;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private LevelPath _levelPath;
    [SerializeField] private UIController _uIController;
    [SerializeField] private List<int> _enemysOnPlatform;

    public bool IsGameStarted => _isGameStarted;
    public bool IsPathEnded => _isPathEnded;


    public void StartGame()
    {
        _uIController.ChangeStartButtonActive(false);
        _isGameStarted = true;
        _levelPath.GoToNextWayPoint();
    }

    public void KillEnemyOnLevel()
    {
        _enemysOnPlatform[_levelPath.CurrentWayPoint - 1]--;
        if (_enemysOnPlatform[_levelPath.CurrentWayPoint - 1] <= 0)
        {
            _levelPath.GoToNextWayPoint();
            
        }
    }

    public void ChangePathStatus(bool pathStatus)
    {
        _isPathEnded = pathStatus;
        CheckLastWayPoint();
    }

    private void CheckLastWayPoint()
    {
        if (_levelPath.CurrentWayPoint == _levelPath.MaxWayPoints && _isPathEnded)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _isGameStarted = false;
        _victoryFemale.SetBool("isVictory", true);
        _playerAnimator.SetBool("isVictory", true);
        _uIController.ShowGameOverScreen();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
