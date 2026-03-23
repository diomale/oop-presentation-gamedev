using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyProximityUI : MonoBehaviour
{
    [Header("Detection")]
    [SerializeField] private float detectRange = 4f;
    [SerializeField] private LayerMask enemyLayer;

    [Header("UI")]
    [SerializeField] private Image warningImage;
    [SerializeField] private float activeAlpha = 1f;
    [SerializeField] private float inactiveAlpha = 0f;
    [SerializeField] private float fadeSpeed = 2f;

    [Header("Scene Transition")]
    [SerializeField] private string sceneToLoad = "SampleScene";
    [SerializeField] private float fullThreshold = 0.98f;

    private bool sceneLoaded = false;

    private void Update()
    {
        bool enemyNearby = Physics2D.OverlapCircle(
            transform.position,
            detectRange,
            enemyLayer
        );

        
        if (enemyNearby && !warningImage.gameObject.activeSelf)
        {
            warningImage.gameObject.SetActive(true);
        }

        if (!warningImage.gameObject.activeSelf) return;

        float targetAlpha = enemyNearby ? activeAlpha : inactiveAlpha;

        Color c = warningImage.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * fadeSpeed);
        warningImage.color = c;

        if (!sceneLoaded && c.a >= fullThreshold)
        {
            sceneLoaded = true;
            SceneManager.LoadScene(sceneToLoad);
        }

        
        if (!enemyNearby && c.a <= 0.05f)
        {
            warningImage.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}