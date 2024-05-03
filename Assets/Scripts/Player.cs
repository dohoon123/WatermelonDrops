using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference click, pointerPosition;

    Vector2 pointerInput;
    SelectCrewComponent SCComponent;
    GameManager gameManager;

    private void Awake() {
        SCComponent = GetComponent<SelectCrewComponent>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update () {
        pointerInput = GetPointerInput();
    }

    private void OnEnable() {
        click.action.performed += PerformClick;
    }

    private void OnDisable() {
        click.action.performed -= PerformClick;
    }

    private void PerformClick(InputAction.CallbackContext context) {
        int randomNumber = UnityEngine.Random.Range(0, 7);
        if (gameManager == null)
        {
            Debug.Log("game manager null!");
            return;
        }
        GameObject go = gameManager.pool.Get(randomNumber, pointerInput);
    }

    private Vector2 GetPointerInput() {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
