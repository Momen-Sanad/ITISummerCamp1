using UnityEngine;

public class PressLever : MonoBehaviour
{
    Animator anim;
    bool pressed = false;

    [SerializeField] LeverManager manager;

    void Awake() =>
        anim = GetComponent<Animator>();

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Q) && !pressed)
        {
            anim.SetBool("isPressed", true);
            pressed = true;

            if (manager != null)
                manager.LeverPressed();
        }
    }
}
