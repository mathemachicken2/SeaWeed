using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource ambientSource;
    public AudioSource sfxSource;

    [Header("Ambient")]
    public AudioClip mainMenuAmbient;
    public AudioClip scene1Ambient;
    public AudioClip scene2Ambient;
    public AudioClip scene3Ambient;
    public AudioClip scene4Ambient;
    public AudioClip endingAmbient;

    [Header("Sound Effects")]
    public AudioClip dialogueSound;
    public AudioClip milkingSound;
    public AudioClip enterSceneChangeSound;
    public AudioClip endGameSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayAmbient(scene.name);
    }

    void PlayAmbient(string sceneName)
    {
        AudioClip clip = null;

        switch (sceneName)
        {
            case "MainMenu":
                clip = mainMenuAmbient;
                break;

            case "Level5":
                clip = scene1Ambient;
                break;

            case "Level3":
                clip = scene2Ambient;
                break;

            case "Level4":
                clip = scene3Ambient;
                break;

            case "Level2":
                clip = scene4Ambient;
                break;

            case "SampleScene":
                clip = endingAmbient;
                break;

            case "MilkLevel":
                clip = endingAmbient;
                break;

            case "FinalScene":
                clip = endingAmbient;
                break;
        }

        if (clip != null && ambientSource.clip != clip)
        {
            ambientSource.clip = clip;
            ambientSource.loop = true;
            ambientSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopAmbient()
    {
        ambientSource.Stop();
    }
}