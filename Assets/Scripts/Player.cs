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

    [SerializeField] float spawnCoolDown;
    private float currentCoolDown;

    Vector2 pointerInput;
    SelectCrewComponent SCComponent;

    private void Awake() {
        currentCoolDown = spawnCoolDown;
        SCComponent = GetComponent<SelectCrewComponent>();
        SCComponent.SetCrew();
    }

    void Update () {
        currentCoolDown += Time.deltaTime;
        pointerInput = GetPointerInput();
    }

    private void OnEnable() {
        click.action.performed += PerformClick;
    }

    private void OnDisable() {
        click.action.performed -= PerformClick;
    }

    private void PerformClick(InputAction.CallbackContext context) {
        if (currentCoolDown <= spawnCoolDown) { return; }
        spawnCoolDown = 0;
        int crewNumber = SCComponent.GetCrewNumber();
        GameManager.instance.pool.Get(crewNumber, new Vector3(pointerInput.x, crewSpawnYPosition, 0));
    }

    private Vector2 GetPointerInput() {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
