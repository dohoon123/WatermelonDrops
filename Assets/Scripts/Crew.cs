using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    [SerializeField] CrewData crewData;

    private void OnCollisionEnter2D(Collision2D other) {
        Crew cd = other.gameObject.GetComponent<Crew>();

        if (cd.crewData.crewNumber == crewData.crewNumber) {
            
        }
        
    }

    [System.Serializable]
    public class CrewData {
        public Sprite sprite;
        public int crewNumber;
        public float mass;
    }
}
