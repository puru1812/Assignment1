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
    bool released = false;


  
    public void Release()
    {
        if(released) return;
        released = true;

        Vector3 myPos= transform.position;
        render.sprite = frames[4];
    
        Debug.Log(myPos + " Releasing Check box" + gameObject.name);
        int index = pattern.allBoxes.IndexOf(this);
        for (int i = index+1; i < pattern.allBoxes.Count; i++)
        {
          //  Debug.Log(pattern.allBoxesPosition[i] + " Check box" + i);
            if (pattern.allBoxes[i].gameObject != null )
            {
               
                    Debug.Log(pattern.allBoxesPosition[i] + "found Check box" + i);
                    if (Mathf.Abs(pattern.allBoxesPosition[i].x - myPos.x)<0.1f&& pattern.allBoxesPosition[i].y> myPos.y)
                {

                    Debug.Log(pattern.allBoxesPosition[i] + "now found Check box" + i);

                    if (pattern.allBoxes[i].GetComponent<Box>().color == color)
                            {
                                pattern.allBoxes[i].GetComponent<Box>().Release();

                            }
                            else
                            {
                                break;
                            }

                        
                    }
                
              
               
            }
        }


        rig.bodyType = RigidbodyType2D.Dynamic;


        pattern.CalculateHeight();
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
    public void SetColor(List<Box> adjuscentBoxes)
    {
        render.sprite = frames[(int)color];
      
    }



}
