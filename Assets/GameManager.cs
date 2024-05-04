using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;

    public Stack<GameObject> crewStack = new();
    [SerializeField] AudioPlayer audioPlayer;


    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    private void Awake() {
        ManageSingleton();
    }

    private void Start() {
        score = 0;
    }

    private void Update() {
        MergeCrews();
    }

    private void MergeCrews() {
        if (crewStack.Count > 1) {
            //calc average value of two gameobjects
            GameObject go1 = crewStack.Pop();
            GameObject go2 = crewStack.Pop();

            if (!go1.TryGetComponent<Crew>(out var cd)) {
                return;
            }

            score += (cd.crewNumber + 1) * 2;
            Vector2 averagePosition = (go1.transform.position + go2.transform.position) / 2;
            pool.Get(cd.crewNumber + 1, averagePosition);

            scoreText.text = score.ToString();
            audioPlayer.PlayMergeSound();
        }
    }

    private void ManageSingleton() {
        if (instance != null) {
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
