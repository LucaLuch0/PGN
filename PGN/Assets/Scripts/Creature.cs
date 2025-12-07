using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creature
{
    private CreatureBase _base;

    public CreatureBase Base
    {
        get => _base;
    }

    private List<Attack> _attacks;

    public List<Attack> Attacks
    {
        get => _attacks;
        set => _attacks = value;
    }

    private int _hp;

    public int HP
    {
        get => _hp;
        set => _hp = value;
    }

    public int MaxHP;
    public Creature(CreatureBase creatureBase)
    {
        _base = creatureBase;

        MaxHP = _base.MaxHP;

        if (MaxHP <= 0)
        {
            MaxHP = 1;
            Debug.LogWarning("Warning: MaxHP was 0. I forced it to 1 to prevent a crash.");
        }
        _hp = MaxHP;
        _attacks = new List<Attack>();

        foreach (var attack in _base.LearnableAttacks)
        {
            if (_attacks.Count > 4)
                break;
            _attacks.Add(new Attack(attack.Attack));
        }

    }


    public bool TakeDamage(int damage)
    {
        _hp -= damage;

        if (_hp < 0)
            _hp = 0;

        return _hp == 0;
    }
}

