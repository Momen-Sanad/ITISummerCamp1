using UnityEngine;

public class LeverManager : MonoBehaviour
{
    int pressedCount = 0;
    [SerializeField] int totalLevers = 2;
    [SerializeField] GameObject objectToDisable;

    public void LeverPressed()
    {
        pressedCount++;
        if (pressedCount >= totalLevers && objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}
