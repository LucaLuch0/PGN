using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using System;

[CreateAssetMenu(fileName = "Creature", menuName = "Creature/New Creature")]
public class CreatureBase : ScriptableObject
{


    [SerializeField] private int ID; public int Id => ID;
    [SerializeField] private string creatureName; public string CreatureName => creatureName;
    [TextArea][SerializeField] private string description; public string Description => description;
    [SerializeField] private Sprite frontSprite; public Sprite FrontSprite => frontSprite;
    [SerializeField] private Sprite backSprite; public Sprite BackSprite => backSprite;

    // Stats
    [SerializeField] private int maxHP; public int MaxHP => maxHP;



    [SerializeField] private List<LearnableAttack> learnableAttacks;
    public List<LearnableAttack> LearnableAttacks => learnableAttacks;

    [Serializable]
    public class LearnableAttack
    {
        [SerializeField] private AttackBase attack;
        [SerializeField] private int level;

        public AttackBase Attack => attack;
        public int Level => level;


    }

}
