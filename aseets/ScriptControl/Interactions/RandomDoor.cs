using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomDoor : InteractableObject
{
    [SerializeField] private string normalScene;
    [SerializeField] private string abnormalScene;

    protected override void Interact()
    {
        if (!playerInRange) return;

        int randomChoice = Random.Range(0, 2);
        string sceneToLoad = (randomChoice == 0) ? normalScene : abnormalScene;

        SceneManager.LoadScene(sceneToLoad);
    }
}