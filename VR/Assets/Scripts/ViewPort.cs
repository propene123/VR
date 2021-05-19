using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class ViewPort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float ratio = (float) Screen.height / (float) Screen.width;

        Camera.main.rect = new Rect((1.0f - ratio)/2.0f, 0.0f, ratio, 1.0f);
        
    }
    
    void Update()
    {
        
        float ratio = (float) Screen.height / (float) Screen.width;

        Camera.main.rect = new Rect((1.0f - ratio)/2.0f, 0.0f, ratio, 1.0f);
        
    }

}
