using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text creatureName;

    private Creature _creature;
    
    public void SetCreatureData(Creature creature)
    {
        _creature = creature;
        creatureName.text = creature.Base.CreatureName;
    }
}
