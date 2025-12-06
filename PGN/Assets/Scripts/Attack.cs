using UnityEngine;

public class Attack : MonoBehaviour
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
