using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] mergeSound;
    [Range(0, 1)]
    [SerializeField] float mergeVolume;
    [SerializeField] AudioSource audioObject;
    static AudioPlayer instance;

    private void Awake() {
        ManageSingleton();
    }//

    void ManageSingleton() {
        if (instance != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayClip(AudioClip audioClip, Vector3 position, float volume) {
        if (audioClip != null && audioObject != null) {
            AudioSource.PlayClipAtPoint(audioClip, position, volume);
            
            //spawn in gameObject
            AudioSource audioSource = Instantiate(audioObject, position, quaternion.identity);

            //assign the audioClip
            audioSource.clip = audioClip;
            audioSource.volume = volume;

            //play sound
            audioSource.Play();

            //get length of sound clip
            float clipLength = audioSource.clip.length;

            //Destroy Audio after it's done playing
            Destroy(audioSource.gameObject, clipLength);
        }
    }

    public void PlayMergeSound() {
        int randomNumber = UnityEngine.Random.Range(0, mergeSound.Length);
        PlayClip(mergeSound[randomNumber], Camera.main.transform.position, mergeVolume);
    }
}