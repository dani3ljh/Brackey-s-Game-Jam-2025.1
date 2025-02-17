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

    [Header("Data")]
    [SerializeField] private string[] codes;
    [SerializeField] private GameObject[] riddles;

    [Header("GameObjects")]
    [SerializeField] private InputField input;
    [SerializeField] private GameObject errorText;
    [SerializeField] private PlayerControls pc;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        foreach (GameObject riddle in riddles) {
            riddle.SetActive(false);
        }
    }

    /// <summary>
    /// On Submit
    /// </summary>
    public void Submit() {
        string inputText = input.text.ToLower().Trim();
        input.text = "";

        int i;
        for (i = 0; i < codes.Length; i++) {
            if (codes[i] == inputText) {
                break;
            }
        }

        if (i == codes.Length) {
            errorText.SetActive(true);
            return;
        }

        print($"Code {inputText} found openning riddle");

        pc.isMenuOpen = false;
        pc.isRiddleOpen = true;
        riddles[i].SetActive(true);
        gameObject.SetActive(false);
    }
}
