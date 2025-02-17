using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes Input to control the player
/// </summary>
public class PlayerControls : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float speed = 10f;
    [HideInInspector] public bool isRiddleOpen = false;
    [HideInInspector] public bool isMenuOpen = false;

    [Header("Game Objects")]
    [SerializeField] private GameObject menu;

    private Rigidbody2D rb;
    private Animator anim;

    private float horiz;
    private float vert;

    /// <summary>
    /// /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        menu.SetActive(false);
        isRiddleOpen = false;
        isMenuOpen = false;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        horiz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Menu") && !isMenuOpen && !isRiddleOpen) {
            isMenuOpen = !isMenuOpen;
            menu.SetActive(isMenuOpen);
        }

        anim.SetBool("isWalking", horiz != 0 || vert != 0);
    }

    /// <summary>
    /// Update is called at 50fps, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate() {
        rb.velocity = Time.deltaTime * speed * new Vector2(horiz, vert);
    }
}
