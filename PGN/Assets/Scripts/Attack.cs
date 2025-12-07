using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Attack 
{
    private AttackBase _base;

    public AttackBase Base
    {
        get => _base;
        set => _base = value;
    }

    public Attack(AttackBase aBase)
    {
        Base = aBase;
    }
}
