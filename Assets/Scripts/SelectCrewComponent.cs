using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectCrewComponent : MonoBehaviour
{
    [SerializeField] Sprite[] crewSprites;
    [SerializeField] Image nextCrewImage;

    private int crewNumber;

    private void Awake() {
        crewNumber = 0;
    }

    public void SetCrew() {
        crewNumber = UnityEngine.Random.Range(0, 2);
        nextCrewImage.sprite = crewSprites[crewNumber];
    }

    public int GetCrewNumber() {
        int currentCrewNumber = crewNumber;
        SetCrew();
        return currentCrewNumber;
    }
}
