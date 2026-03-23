using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableObject : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] protected GameObject interactionButton;

    protected Button button;
    protected bool playerInRange = false;

    protected virtual void Awake()
    {
        if (interactionButton != null)
            button = interactionButton.GetComponent<Button>();
    }

    protected virtual void Start()
    {
        if (interactionButton != null)
            interactionButton.SetActive(false);

        if (button != null)
            button.onClick.AddListener(Interact);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        playerInRange = true;

        if (interactionButton != null)
            interactionButton.SetActive(true);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        playerInRange = false;

        if (interactionButton != null)
            interactionButton.SetActive(false);
    }

    protected abstract void Interact();
}