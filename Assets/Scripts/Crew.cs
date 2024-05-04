using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    public CrewData crewData;

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (!other.gameObject.TryGetComponent<Crew>(out var cd)) {
            return;
        }

        if (crewData.crewNumber >= 6) {
            return;
        }

        if (cd.crewData.crewNumber == crewData.crewNumber) {
            //need to add score later

            GameManager.instance.crewStack.Push(gameObject);
            gameObject.SetActive(false);

        }
    }

    [System.Serializable]
    public class CrewData {
        public int crewNumber;
        public float mass;
    }
}
