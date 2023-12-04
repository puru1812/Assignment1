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
    public Canon canon;

    private void OnEnable()
    {
        float x = -2.4f;
        float y = 4.5f; ;
        int k = 0;
        int c = 0 ;
        List<Box> boxes = new List<Box>();

        
        for(int i = 0; i < 250; i++)
        {
            GameObject boxnew=Instantiate(boxObject, new Vector3(x, y, 0),Quaternion.identity);

            boxnew.GetComponent<Box>().color = (Color)c;
            boxnew.GetComponent<Box>().canon = canon;
            boxnew.name = "box" + i;
            boxnew.SetActive(true);
            allBoxes.Add(boxnew.GetComponent<Box>());

            x = x + 0.36f;
       
            if (x > 2.5)
            {
                x = -2.4f;
                y = y - 0.35f;
            }

            boxnew.GetComponent<Box>().SetColor();
          k++;
            if (k == 45)
            {
                k = 0;
                int c1= (Random.Range(0, 2));
              
                c = c1;
            }

        }
        for (int i = 0; i < allBoxes.Count; i++)
        {
            if(i+14 < allBoxes.Count)
            allBoxes[i].bottombox = allBoxes[i + 14];

            if (i - 14 >= 0)
            {
                allBoxes[i].topbox = allBoxes[i - 14];
            }
        }
            
    }
   
}
