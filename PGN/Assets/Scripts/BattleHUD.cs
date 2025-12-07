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
        healthBar.SetHP((float)creature.HP / creature.MaxHP);
    }

    public void UpdateHP(int currentHP, int maxHP)
    {
        healthBar.SetHP((float)currentHP / maxHP);
    }
}