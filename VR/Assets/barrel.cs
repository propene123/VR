using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    
    public Material shader;
    public Material shadern;
    public RenderTexture kek;
    
    
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src,dest,shader);
        //Graphics.Blit(kek,dest,shadern);
    }
    
    
}
