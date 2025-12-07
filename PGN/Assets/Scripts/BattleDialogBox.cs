using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] private GameObject attackSelect;
    [SerializeField] private List<Text> attackTexts;
    [SerializeField] private List<GameObject> attackButtons;
    [SerializeField] private BattleUnit playerUnit;
    public bool isWriting = false;
    public float charactersPerSecond;
    public IEnumerator SetDialog(string message)
    {
        isWriting = true;
        dialogText.text = "";
        foreach (var character in message)
        {
            dialogText.text += character;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
        yield return new WaitForSeconds(1f);
    }
    
    public void ToggleDialogText(bool activated)
    {
        dialogText.enabled = activated;
    }

    public void ToggleAttacks(bool activated)
    {
        attackSelect.SetActive(activated);
    }
}
