using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles Input of the Riddle
/// </summary>
public class RiddleManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private string answer;

    [Header("GameObjects")]
    [SerializeField] private InputField input;
    [SerializeField] private GameObject errorText;
    [SerializeField] private PlayerControls pc;

    /// <summary>
    /// /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        errorText.SetActive(false);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        if (Input.GetButtonDown("Menu")) {
            pc.isRiddleOpen = false;
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// On answer submit
    /// </summary>
    public void Submit() {
        string inputText = input.text.ToLower().Trim();
        input.text = "";

        if (inputText != answer) {
            errorText.SetActive(true);
            return;
        }

        pc.isRiddleOpen = false;
        gameObject.SetActive(false);
    }
}
