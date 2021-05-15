using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    
    
    public bool inv;
    public Material shader;
    public Material shadern;
    public RenderTexture kek;
    
    
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if(inv)
        {
            Graphics.Blit(src,kek,shader);
            Graphics.Blit(kek,dest,shadern); 
            
        }else
        {
            Graphics.Blit(src,dest,shader);
        }
    }
    
    
}
