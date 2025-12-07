using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text creatureName;

    public HealthBar healthBar;
    
    public void SetCreatureData(Creature creature)
    {
        creatureName.text = creature.Base.CreatureName;
        healthBar.SetHP(creature.HP/creature.MaxHP);
    }
}