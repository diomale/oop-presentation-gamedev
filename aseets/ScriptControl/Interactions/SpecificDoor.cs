using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecificDoor : InteractableObject
{
    [SerializeField] private string sceneToLoad;

    protected override void Interact()
    {
        if (!playerInRange) return;

        SceneManager.LoadScene(sceneToLoad);
    }
}