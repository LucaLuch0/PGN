using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Creature(CreatureBase creatureBase)
    {
        _base = creatureBase;

        _hp = MaxHP;
        _attacks = new List<Attack>();

        foreach (var attack in _base.LearnableAttacks)
        {
            if (_attacks.Count > 4)
                break;
        }
    }

    public int MaxHP;
    
}

