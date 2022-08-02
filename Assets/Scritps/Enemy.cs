using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Animator _enemyAnimator;
    private GameController _gameController;
    private BoxCollider _enemyHitbox;
    private HealthBarRotation _healthBarRotation;
    [SerializeField] private List<Rigidbody> _enemyRagdoll;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _healthBarUI;
    [SerializeField] private Slider _healthSlider;

    private void Awake()
    {
        _healthBarRotation = _healthBarUI.GetComponent<HealthBarRotation>();
        _health = _maxHealth;
        _healthSlider.value = CalculateHealth();
        _enemyHitbox = GetComponent<BoxCollider>();
        _enemyAnimator = GetComponent<Animator>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void GettingDamage(float damage)
    {
        _health -= damage;
        _healthSlider.value = CalculateHealth();
        if (_health < _maxHealth)
        {
            _healthBarRotation.enabled = true;
            _healthBarUI.SetActive(true);
            
        }
        if(_health <= 0)
        {
            _healthBarRotation.enabled = false;
            _healthBarUI.SetActive(false);
            _gameController.KillEnemyOnLevel();
            ActivateRagdoll();
        }
    }

    private float CalculateHealth()
    {
        return _health / _maxHealth;
    }

    private void ActivateRagdoll()
    {
        _enemyHitbox.enabled = false;
        _enemyAnimator.enabled = false;
        foreach (var item in _enemyRagdoll)
        {
            item.isKinematic = false;
        }
    }
}
