using System.Collections;
using UnityEngine;
using TMPro;

public class CreditsDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;

    // You can change this number in the Inspector if you want it longer/shorter
    public float timeUntilClose = 5.0f;

    void Start()
    {
        // 1. Take all the lines from the Inspector and join them into one block of text.
        // "\n" creates a new line between each sentence.
        textComponent.text = string.Join("\n", lines);

        // 2. Start the timer to close the game
        StartCoroutine(WaitAndQuit());
    }

    IEnumerator WaitAndQuit()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(timeUntilClose);

        // Quit the game
        Debug.Log("Time is up! Quitting Game...");
        Application.Quit();
    }
}
