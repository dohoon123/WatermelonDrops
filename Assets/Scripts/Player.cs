using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference click, pointerPosition;
    [SerializeField] private float crewSpawnYPosition;

    Vector2 pointerInput;
    SelectCrewComponent SCComponent;

    private void Awake() {
        SCComponent = GetComponent<SelectCrewComponent>();
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
        int randomNumber = UnityEngine.Random.Range(0, 2);
        GameManager.instance.pool.Get(randomNumber, new Vector3(pointerInput.x, crewSpawnYPosition, 0));
    }

    private Vector2 GetPointerInput() {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
