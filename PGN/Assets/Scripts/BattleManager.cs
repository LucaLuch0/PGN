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

    [SerializeField] GameObject attackButtons;

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

        yield return battleDialogBox.SetDialog($"An {enemyUnit.Creature.Base.CreatureName} has appeared!");
        yield return battleDialogBox.SetDialog("Choose an action");
    }

    public void OnAttackButton(int moveIndex)
    {
        // Safety: If the button asks for a move we don't have, ignore it.
        if (moveIndex >= playerUnit.Creature.Attacks.Count) return;

        StartCoroutine(PlayerAttack(moveIndex));
    }

    IEnumerator PlayerAttack(int moveIndex)
    {
        var attack = playerUnit.Creature.Attacks[moveIndex];

        yield return battleDialogBox.SetDialog($"You used {attack.Base.Name}!");

        yield return new WaitForSeconds(1f);

        int damage = attack.Base.Power;
        bool isDead = enemyUnit.Creature.TakeDamage(damage);

        enemyHUD.UpdateHP(enemyUnit.Creature.HP, enemyUnit.Creature.MaxHP);

        if (isDead)
        {
            yield return battleDialogBox.SetDialog($"{enemyUnit.Creature.Base.CreatureName} Fainted!");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        yield return battleDialogBox.SetDialog($"The enemy is attacking!");
        yield return new WaitForSeconds(1f);

        int randomMove = Random.Range(0, 2);
        var attack = enemyUnit.Creature.Attacks[randomMove];

        yield return battleDialogBox.SetDialog($"Enemy used {attack.Base.Name}!");
        yield return new WaitForSeconds(1f);

        int damage = attack.Base.Power;
        bool isDead = playerUnit.Creature.TakeDamage(damage);
        playerHUD.UpdateHP(playerUnit.Creature.HP, playerUnit.Creature.MaxHP);

        if (isDead)
        {
            yield return battleDialogBox.SetDialog("You Fainted...");
        }
        else
        {
            yield return battleDialogBox.SetDialog("Choose an action");
            attackButtons.SetActive(true);
        }
    }
}