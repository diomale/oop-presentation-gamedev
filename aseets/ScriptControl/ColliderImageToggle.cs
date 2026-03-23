using UnityEngine;
using UnityEngine.UI;

public class ColliderImageToggle : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject targetImage;
    [SerializeField] private GameObject toggleButton;

    private Button button;
    private bool playerInRange = false;

    private void Awake()
    {
        if (toggleButton != null)
            button = toggleButton.GetComponent<Button>();
    }

    private void Start()
    {
        // Hide button and image at start
        if (toggleButton != null)
            toggleButton.SetActive(false);

        if (targetImage != null)
            targetImage.SetActive(false);

        // Assign button event
        if (button != null)
            button.onClick.AddListener(ToggleImage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        playerInRange = true;

        if (toggleButton != null)
            toggleButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        playerInRange = false;

        if (toggleButton != null)
            toggleButton.SetActive(false);

        // Optional: hide image when player leaves
        if (targetImage != null)
            targetImage.SetActive(false);
    }

    private void ToggleImage()
    {
        if (!playerInRange) return;

        if (targetImage != null)
            targetImage.SetActive(!targetImage.activeSelf);
    }
}