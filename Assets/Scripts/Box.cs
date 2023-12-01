using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    public Color color;
    public Rigidbody2D rig;
    public SpriteRenderer render;
    public List<Sprite> frames=new List<Sprite> ();
    public Canon canon;
    public BoxCollider2D collider;
    public Pattern pattern;
    public bool released = false;
    public Box bottombox = null;

    public Box topbox = null;

    public void Release()
    {
        if(released) return;
     

        Vector3 myPos= transform.position;
        render.sprite = frames[4];
    
       // Debug.Log(myPos + " Releasing Check box" + gameObject.name);
        released = true;
       if(bottombox != null)
        {
            if(bottombox.color==color)
            bottombox.Release();
        }
        rig.bodyType = RigidbodyType2D.Dynamic;
      
    }
  
    private void Update()
    {
        if (canon.currentBullet != null)
        {
            if (collider.bounds.Contains(canon.currentBullet.gameObject.transform.position))
            {
               // print("point is inside collider");
                if (color == canon.currentBullet.GetComponent<Bullet>().color)
                {
                    Release();
                }

            }

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
    public void SetColor()
    {
        render.sprite = frames[(int)color];
      
    }



}
