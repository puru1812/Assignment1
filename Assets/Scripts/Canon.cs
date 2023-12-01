using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalPosition= Vector3.zero;
    bool selected = false;
    public GameObject bullet;
    public GameObject currentBullet = null;
    public Color chosenColor = Color.Red;
  
    void OnEnable()
    {
        originalPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
       // Debug.Log("OnMouseOver");
        if (selected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance= originalPosition.x - mousePos.x;
            float angle = distance * 120;
            if (Mathf.Abs(angle) > 60)
            {
                angle = Mathf.Sign(angle) * 60;
            }
          
     
            transform.eulerAngles = new Vector3(0, 0, angle);
           
        }
    }
    public void OnMouseDown()
    {
       // Debug.Log("OnMouseDown");
        selected = true;
    }
    public void OnMouseUp()
    {
        // Debug.Log("OnMouseUp");
        selected = false;
        if (currentBullet == null)
        {
            currentBullet = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
            currentBullet.GetComponent<Bullet>().color = chosenColor;
            if (chosenColor == Color.Red)
            {
                currentBullet.GetComponent<Bullet>().dot.color = UnityEngine.Color.red;
            }
            else if (chosenColor == Color.Green)
            {
                currentBullet.GetComponent<Bullet>().dot.color = UnityEngine.Color.green;
            }
            else if (chosenColor == Color.Blue)
            {
                currentBullet.GetComponent<Bullet>().dot.color = UnityEngine.Color.blue;
            }
            else
            {
                currentBullet.GetComponent<Bullet>().dot.color = UnityEngine.Color.yellow;
            }
            currentBullet.transform.position = transform.position;
            currentBullet.transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z/2);
            currentBullet.SetActive(true);
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("Collision canon");

    }
}
