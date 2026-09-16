using UnityEngine;
public class ChangeColor : MonoBehaviour{
    [SerializeField] private Color endColor;
    [SerializeField] private float time;

    private Color startColor;
    private float chrono = 0f;

    private void Start()
    {
        if(TryGetComponent(out Renderer renderer))
        {
            startColor = renderer.material.color;
        }
        else        {
            Debug.LogError("This component needs a renderer to work correctly.");
        }
    }

    private void Update()
    {
        chrono += Time.deltaTime;
        float progression = chrono / time;
        // Debug.Log($"time : {time}, chrono : {chrono}, progression {progression}");
        
        if(TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = Color.Lerp(startColor, endColor, progression); // C'est le Lerp qui gère la progression d'une couleur à l'autre
        }
        else        
        {
            Debug.LogError("This component needs a renderer to work correctly.");
        }
    }
}
 
 
