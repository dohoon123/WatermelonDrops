using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Player player;

    public static GameManager instance;
    public PoolManager pool;

    [Header("Audio")]
    public Stack<GameObject> crewStack = new();
    [SerializeField] AudioPlayer audioPlayer;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    [SerializeField] TextMeshProUGUI successImage;
    [SerializeField] Button restartButton;

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

    public void RestartGame() {
        successImage.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();

        crewStack.Clear();
        pool.DeleteAll();

        player.SetIsPlaying(true);
    }

    public void EndGame() {
        successImage.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        player.SetIsPlaying(false);
    }

    public void AddScore(int inScore) {
        score += inScore;
    }

    public int GetScore() {
        return score;
    }
}
