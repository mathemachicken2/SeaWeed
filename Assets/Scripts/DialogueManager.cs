using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialoguePanel;

    public ImageOverlay imageOverlay;

    public TMP_Text speakerText;
    public TMP_Text dialogueText;

    public GameObject choicePanel;

    public Button option1;
    public Button option2;

    private DialogueData currentDialogue;
    private int index;

    private Coroutine typingCoroutine;
    private bool isTyping;
    public float typingSpeed = 0.03f;

    private DialogueData sceneDialogue;
    public SceneController sceneController;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /**
    private void Start()
    {
        option1.onClick.AddListener(Option1);
        option2.onClick.AddListener(Option2);

    }
    **/

    
    void Update()
    {
        if (!dialoguePanel.activeSelf)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);

                dialogueText.text = currentDialogue.lines[index].text;
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DialogueData newDialogue = FindFirstObjectByType<DialogueData>();

    }
    public void StartDialogue(DialogueData dialogue)
    {
        Debug.Log("Starting dialogue: " + dialogue.name);
        StartCoroutine(ShowDialogueAfterDelay(3f));
        currentDialogue = dialogue;
        index = 0;
        choicePanel.SetActive(false);

        ShowCurrentLine();
    }
    private IEnumerator ShowDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialoguePanel.SetActive(true);
    }

    public void NextLine()
    {
        index++;

        if (index >= currentDialogue.lines.Length)
        {
            ShowChoices();
            return;
        }

        ShowCurrentLine();
    }

    void ShowCurrentLine()
    {
        speakerText.text = currentDialogue.lines[index].speaker;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.dialogueSound);

        typingCoroutine = StartCoroutine(TypeText(currentDialogue.lines[index].text));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;

        dialogueText.text = "";

        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void ShowChoices()
    {
        dialoguePanel.SetActive(false);
        choicePanel.SetActive(true);

        option1.GetComponentInChildren<TMP_Text>().text =
            currentDialogue.option1Text;

        option2.GetComponentInChildren<TMP_Text>().text =
            currentDialogue.option2Text;
    }
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    public void Option1()
    {
        sceneController.LoadNextScene();
 
    }

    public void Option2()
    {
        StartCoroutine(imageOverlay.FadeToWhite());
    }
}