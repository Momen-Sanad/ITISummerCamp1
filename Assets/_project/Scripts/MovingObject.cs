using UnityEditorInternal;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    Vector3 StartPos;

    bool moving = true;

    public float speed = 5f;
    public float distance = 3f;


    void Start()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
        
        if(rb)
            rb.bodyType = RigidbodyType2D.Kinematic;

    }

    void Update()
    {

        if (moving)
        {

            transform.position += speed * Vector3.right * Time.deltaTime;
            
            if( Vector3.Distance(StartPos, transform.position) >= distance )
            {
                moving = false;
            }
         
        }
        else
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
            if( Vector3.Distance(StartPos, transform.position) <= 0.05 )
            {
                moving = true;
            }
        }
    }
}
