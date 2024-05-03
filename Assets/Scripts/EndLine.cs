using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    EdgeCollider2D myCollider;

    public void Awake() {
        myCollider = GetComponent<EdgeCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        //if (other.TryGetComponent<Health>(out var health)) {

        //}
    }
}
