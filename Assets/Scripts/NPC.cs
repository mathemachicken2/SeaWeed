using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    private DialogueData dialogue;

    void Start()
    {
        Debug.Log("NPC started in scene: " + gameObject.scene.name);

        dialogue = FindFirstObjectByType<DialogueData>();

        Debug.Log("NPC using dialogue: " + dialogue.gameObject.scene.name);

        Talk();
    }

    public void Talk()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}