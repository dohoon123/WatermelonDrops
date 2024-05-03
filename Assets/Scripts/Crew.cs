using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    [SerializeField] CrewData myCrewData;

    private void OnCollisionEnter2D(Collision2D other) {
        Crew cd = other.gameObject.GetComponent<Crew>();
    }

    [System.Serializable]
    public class CrewData {
        public Sprite sprite;
        public int crewNumber;
        public float mass;
    }
}
