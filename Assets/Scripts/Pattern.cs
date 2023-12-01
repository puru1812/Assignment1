using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boxObject;
    public ColorDetector colorDetector;
    public List<Box> allBoxes=new List<Box>();
    public List<Vector3> allBoxesPosition = new List<Vector3>();
    public Canon canon;

    private void OnEnable()
    {
        float x = -2.7f;
        float y = 4.5f; ;
        int k = 0;
        int c = 0 ;
        List<Box> boxes = new List<Box>();

        
        for(int i = 0; i < 200; i++)
        {
            Instantiate(boxObject, new Vector3(x, y, 0),Quaternion.identity);
            boxObject.GetComponent<Box>().color = (Color)c;
            boxObject.GetComponent<Box>().canon = canon;
            boxObject.name = "box" + i;
            boxObject.SetActive(true);
            allBoxes.Add(boxObject.GetComponent<Box>());
            allBoxesPosition.Add(new Vector3(x, y, 0));

            x = x + 0.38f;
       
            if (x > 2.7)
            {
                x = -3.0f;
                y = y - 0.35f;
            }
         
            boxObject.GetComponent<Box>().SetColor(boxes);
          k++;
            if (k == 30)
            {
                k = 0;
                int c1= (Random.Range(0, 4));
              
                c = c1;
            }

        }
        CalculateHeight();
    }
    public void  CalculateHeight()
    {
        colorDetector.maxheight = 10.0f;
        for (int i = 0; i < allBoxes.Count; i++)
        {
            if (allBoxes[i] != null)
            {
                if((allBoxes[i].transform.position.y- colorDetector.gameObject.transform.position.y)<colorDetector.maxheight)
                {
                    colorDetector.maxheight = Mathf.Abs(allBoxes[i].transform.position.y - colorDetector.gameObject.transform.position.y);
                }
            }
        }
        colorDetector.maxheight = colorDetector.maxheight + 3.0f;
        //Debug.Log("maxheight" + colorDetector.maxheight);
    }
}
