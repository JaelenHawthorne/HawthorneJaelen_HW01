using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _treasureCount = 0;
    int _currentHealth;
    BallMotor _ballMotor;
    [SerializeField] Text _treasureScore;
    [SerializeField] Text _healthScore;

    Renderer rend;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _treasureCount = 0;
    }

    public void IsInvincible()
    {
        rend.material.SetColor("_color", Color.blue);
        _currentHealth += 100;
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureCount += amount;
        Debug.Log("Treasure obtained: " + _treasureCount);
        _treasureScore.text = _treasureCount.ToString();
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
        _healthScore.text = "health: " + _currentHealth.ToString();
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        _healthScore.text = "health: " + _currentHealth.ToString();
        if (_currentHealth <=0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        // play particles
        // play sounds
    }

    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }
}
