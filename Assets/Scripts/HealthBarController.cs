using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;
    public PlayerController player;

    public void Start()
    {
        healthBar.maxValue = PlayerController.MAX_HEALTH;
        healthBar.value = PlayerController.MAX_HEALTH;
    }

    public void UpdateHealthBar()
    {
        healthBar.value = player.health;
    }
}
