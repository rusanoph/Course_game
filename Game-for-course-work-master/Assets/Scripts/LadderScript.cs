using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    [SerializeField]

    float LSpeed = 20f;

    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LSpeed);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1 * LSpeed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.000000000000000001f);
            }
        }
    }
   void OnTriggerExit2D(Collider2D other)
   {
        other.GetComponent<Rigidbody2D>().gravityScale = 1;
   }

}
