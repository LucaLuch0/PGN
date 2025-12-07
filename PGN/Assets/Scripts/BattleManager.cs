using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;

    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHUD enemyHUD;

    [SerializeField] BattleDialogBox battleDialogBox;   
    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerUnit.SetupCreature();
        playerHUD.SetCreatureData(playerUnit.Creature);

        enemyUnit.SetupCreature();
        enemyHUD.SetCreatureData(enemyUnit.Creature);

        yield return (battleDialogBox.SetDialog($"An {enemyUnit.Creature.Base.name} creature has appeared"));

    }
}
