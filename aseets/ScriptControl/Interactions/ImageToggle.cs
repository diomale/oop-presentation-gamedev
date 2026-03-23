using UnityEngine;

public class ImageToggleInteractable : InteractableObject
{
    [SerializeField] private GameObject targetImage;

    protected override void Interact()
    {
        if (!playerInRange) return;

        targetImage.SetActive(!targetImage.activeSelf);
    }
}