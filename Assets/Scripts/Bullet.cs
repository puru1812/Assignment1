using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public enum Color
{
    Red,
    Green,
    Blue,
    Yellow
}
public class Bullet : MonoBehaviour
{
        public Color color;
        public float speed = 20;
    public SpriteRenderer dot;
    public Transform parent;
   
    void FixedUpdate()
        {
        transform.Translate(transform.up * speed * Time.deltaTime);
        Ray2D ray =  new Ray2D(transform.position, transform.up);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, speed * Time.deltaTime + 0.5f);
        if (hit.collider != null && hit.collider.CompareTag("Edge"))
        {
            //Debug.Log("hitting");
            Reflect(hit);

        }
        else if (hit.collider != null && hit.collider.CompareTag("Border"))
        {

            Destroy(gameObject);
        }
        
             hit = Physics2D.Raycast(transform.position, transform.up, 0.01f );

            if (hit.collider != null && hit.collider.CompareTag("Box")) { 
                Box box = hit.collider.gameObject.GetComponent<Box>();
            if (color != box.color)
            {
              
                Reflect(hit);
            }
        
        }
       

    }
    public void Reflect(RaycastHit2D hit)
    {
        Vector3 refelct = Vector3.Reflect(transform.up, hit.normal);
        float rot = Mathf.Atan2(refelct.y, refelct.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, rot);
    }  





}
