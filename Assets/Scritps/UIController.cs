using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _gameOverPanel;

    public void ChangeStartButtonActive(bool activeStatus)
    {
        _startButton.gameObject.SetActive(activeStatus);
    }

    public void ShowGameOverScreen()
    {
        _gameOverPanel.SetActive(true);
        _gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, 1).SetDelay(1);
    }
}
