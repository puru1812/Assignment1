using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer dots;
    public Canon canon;
  
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray2D ray = new Ray2D(transform.position, transform.up);
        for (float distance = 0.25f; distance < 15; distance = distance + 0.25f) { 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance);
            if (hit.collider != null && hit.collider.CompareTag("Box"))
            {
                canon.chosenColor = hit.collider.GetComponent<Box>().color;
                if (canon.chosenColor == Color.Red)
                {
                    dots.color = UnityEngine.Color.red;
                }
                else if (canon.chosenColor == Color.Green)
                {
                    dots.color = UnityEngine.Color.green;
                }
                else if (canon.chosenColor == Color.Blue)
                {
                    dots.color = UnityEngine.Color.blue;
                }
                else
                {
                    dots.color = UnityEngine.Color.yellow;
                }
                //  Debug.Log("hitting");
                break;
            }


        }
    }
}
