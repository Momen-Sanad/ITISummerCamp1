using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] 
    AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(pickupSound);

            ScoreManager.Instance.AddScore(10); 
            gameObject.SetActive(false);
        }
    }
}
