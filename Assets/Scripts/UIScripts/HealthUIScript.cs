using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUIScript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    HealthComponent PlayerHealthComponent;
    

    private void OnHealthInitialized(HealthComponent healthComponent)
    {
        PlayerHealthComponent = healthComponent;
    }

    private void OnEnable()
    {
        PlayerEvents.OnHealthInitialized += OnHealthInitialized;
    }

    private void OnDisable()
    {
        PlayerEvents.OnHealthInitialized -= OnHealthInitialized;
    }

    private void Update()
    {
        healthText.text = PlayerHealthComponent.CurrentHealth.ToString() + 
            " / " + PlayerHealthComponent.MaxHealth.ToString();

    }
}
