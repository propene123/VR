using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Question
{
    Q1_Pre_Distortion_Fragment_Shader,
    Q2_LCA_Correction_Fragment_Shader,
    Q3_Pre_Distortion_Mesh_Vertex_Shader
}


public enum Vertices
{
    Sixteen,
    Thirty_Two,
    Sixty_Four
}

[ExecuteAlways]
public class SceneManagerScript : MonoBehaviour
{
    public Question question;
    public Vertices Q3_Mesh_Vertex_Count;
    public bool inverse = false;
    public float c1 = -0.25f;
    public float c2 = 0.05f;
    public float LCA_C1 = 0.1f;
    public float LCA_C2 = -0.05f;
    public Material main_shader;
    public Material lens_shader;    
    
    
    void handleQ1()
    {
        main_shader.shader = Shader.Find("Custom/BarrelFrag");
        main_shader.SetFloat("_c1",c1);
        main_shader.SetFloat("_c2",c2);
        lens_shader.shader = Shader.Find("Custom/Inv");
        lens_shader.SetFloat("_c1",c1);
        lens_shader.SetFloat("_c2",c2);
        if(!inverse)
        {
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Quads"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens"));
        }else
        {
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quads"));
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens"));
        }
    }
    
    void handleQ2()
    {
        main_shader.shader = Shader.Find("Custom/ChromFrag");
        main_shader.SetFloat("_c1",LCA_C1);
        main_shader.SetFloat("_c2",LCA_C2);
        lens_shader.shader = Shader.Find("Custom/ChromInv");
        lens_shader.SetFloat("_c1",LCA_C1);
        lens_shader.SetFloat("_c2",LCA_C2);
        if(!inverse)
        {
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Quads"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens"));
        }else
        {
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quads"));
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens"));
        }
    }
    
    void handleQ3()
    {
        
        
    }
    
    
    
    // Start is called before the first frame update
    void Update()
    {
        switch (question)
        {
            case Question.Q1_Pre_Distortion_Fragment_Shader:
                handleQ1();
                break;
            case Question.Q2_LCA_Correction_Fragment_Shader:
                handleQ2();
                break;
            case Question.Q3_Pre_Distortion_Mesh_Vertex_Shader:
                handleQ3();
                break;
        }
        
    }

}
