using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public Transform[] layers;
    public float scrollSpeed = 10f;
    float spriteWidth;

    void Start()
    {
        spriteWidth = layers[0].GetComponent<SpriteRenderer>().bounds.size.x/3 +5;
    }

    void Update()
    {
        foreach (Transform layer in layers)
        {
            // Move layer left
            layer.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // When layer is off screen, move it to the right end
            if (layer.position.x < -spriteWidth)
            {
                layer.position += Vector3.right * spriteWidth * (layers.Length - 1);
            }
        }
    }
}
