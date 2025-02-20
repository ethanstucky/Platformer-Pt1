using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Renderer rend;
    public float timeElapsed;
    public float interval;
    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        while (timeElapsed >= interval)
        {
            timeElapsed -= interval;
            rend.material.mainTextureOffset += new Vector2(0f, 0.2f);
        }
        if (rend.material.mainTextureOffset.y > 0.8f)
        {
            rend.material.mainTextureOffset = new Vector2(0f, 0f);
        }
    }
}
