using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    public CreatureBase _base;

    public bool isPlayer;

    public Creature Creature {get; set;}

    private Image creatureImage;

    private void Awake()
    {
        creatureImage = GetComponent<Image>();
    }

    public void SetupCreature()
    {
        Creature = new Creature(_base);

        if (isPlayer)
        {
            creatureImage.sprite = Creature.Base.BackSprite;
        }
        else
        {
            creatureImage.sprite = Creature.Base.FrontSprite;
        }
    }

}
