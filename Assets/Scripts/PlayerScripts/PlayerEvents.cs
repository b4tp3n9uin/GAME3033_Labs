using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void OnWeaponEqippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEqippedEvent OnWeaponEquipped;

    public static void InvokeOnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }

    public delegate void OnHealthInitializeEvent(HealthComponent healthComponent);

    public static event OnHealthInitializeEvent OnHealthInitialized;

    public static void InvokeOnHealthInitialized(HealthComponent healthComponent)
    {
        OnHealthInitialized?.Invoke(healthComponent);
    }

}
