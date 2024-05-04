using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : MonoBehaviour
{
    public int crewNumber;
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (!other.gameObject.TryGetComponent<Crew>(out var cd)) {
            return;
        }

        if (crewNumber >= 6) {
            return;
        }

        if (cd.crewNumber == crewNumber) {
            //need to add score later

            GameManager.instance.crewStack.Push(gameObject);
            gameObject.SetActive(false);

        }
    }


}
