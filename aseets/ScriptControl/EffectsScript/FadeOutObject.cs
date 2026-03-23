using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float setDeactive = 0.01f;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite == null) return;

        Color c = sprite.color;

        c.a = Mathf.MoveTowards(c.a, 0f, fadeSpeed * Time.deltaTime);

        sprite.color = c;

        
        if (c.a <= setDeactive)
        {
            gameObject.SetActive(false);
        }
    }
}