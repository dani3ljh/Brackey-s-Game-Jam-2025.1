using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles Input of Secret Codes
/// </summary>
public class SecretManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private RiddleManager[] riddles;
    [SerializeField] private InputField input;
    [SerializeField] private GameObject errorText;
    [SerializeField] private GameObject redeemedText;
    [SerializeField] private PlayerControls pc;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        foreach (RiddleManager riddle in riddles) {
            riddle.gameObject.SetActive(false);
        }
        errorText.SetActive(false);
        redeemedText.SetActive(false);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        if (Input.GetButtonDown("Menu")) {
            pc.isMenuOpen = false;
            errorText.SetActive(false);
            redeemedText.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// On Submit
    /// </summary>
    public void Submit() {
        string inputText = input.text.ToLower().Trim();
        input.text = "";

        int i;
        for (i = 0; i < riddles.Length; i++) {
            if (riddles[i].code == inputText) {
                break;
            }
        }

        if (i == riddles.Length) {
            errorText.SetActive(true);
            return;
        }

        if (riddles[i].hasSolved) {
            redeemedText.SetActive(true);
            return;
        }

        print($"Code {inputText} found openning riddle");

        pc.isMenuOpen = false;
        pc.isRiddleOpen = true;
        riddles[i].gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
