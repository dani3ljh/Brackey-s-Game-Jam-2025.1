using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles Loading Scenes
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Loads scene from build index
    /// </summary>
    /// <param name="buildIndex">Index of scene in build</param>
    public void LoadScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }

    /// <summary>
    /// Loads scene from scene name
    /// </summary>
    /// <param name="sceneName">Scene name</param>
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
