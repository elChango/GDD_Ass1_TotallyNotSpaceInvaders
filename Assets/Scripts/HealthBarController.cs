using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthBar;

    public void Start()
    {
        healthBar.maxValue = ConstantsHelper.MAX_PLAYER_HEALTH;
        healthBar.value = ConstantsHelper.MAX_PLAYER_HEALTH;
    }

    public void UpdateHealthBar(int playerHealth)
    {
        healthBar.value = playerHealth;
    }
}
