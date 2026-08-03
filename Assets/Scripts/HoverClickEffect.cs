using UnityEngine;

public class HoverClickEffect : MonoBehaviour
{
    [Header("Hover Colour")]
    public MeshRenderer meshRenderer;
    public Color hoverColor = Color.cyan;

    private Color originalColor;

    [Header("Click Animation")]
    public Animator animator;
    public string clickTrigger = "Hover";

    [Header("Click Particles")]
   
    public ParticleSystem particlePrefab;
    public Transform[] particleSpawnPoints;

    public GameObject optionPanel;

    void Start()
    {
        if (meshRenderer == null)
            meshRenderer = GetComponent<MeshRenderer>();

        originalColor = meshRenderer.material.color;

        optionPanel.SetActive(false);
    }

    void OnMouseEnter()
    {
        // Change colour only
        meshRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        // Return colour
        meshRenderer.material.color = originalColor;
    }

    private int clickCount = 0;
    void OnMouseDown()
    {
        clickCount++;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.milkingSound);
        // Play animation
        if (animator != null)
            animator.SetTrigger("Hover");

        foreach (Transform spawnPoint in particleSpawnPoints)
        {
            if (spawnPoint != null)
            {
                ParticleSystem ps = Instantiate(
                    particlePrefab,
                    spawnPoint.position,
                    spawnPoint.rotation);

                Destroy(ps.gameObject, 2f);
            }
        }
        if (clickCount >= 4)
        {
            optionPanel.SetActive(true);
        }
    }
}