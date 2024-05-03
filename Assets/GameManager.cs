using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    int score;

    private void Awake() {
        ManageSingleton();
    }

    private void Start() {
        score = 0;
    }

    private void ManageSingleton() {
        if (instance == null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int inScore) {
        score += inScore;
    }

    public int GetScore() {
        return score;
    }
}
