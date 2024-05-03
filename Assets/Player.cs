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
        Debug.Log("Clicked!");
    }

    private Vector2 GetPointerInput() {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
