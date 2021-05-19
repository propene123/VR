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

public class SceneManagerScript : MonoBehaviour
{
    public Question question;
    public Vertices Q3_Mesh_Vertex_Count;
    public bool inverse;
    public float c1 = -0.25f;
    public float c2 = 0.05f;
    public float LCA_C1 = 0.1f;
    public float LCA_C2 = -0.05f;
    public Material main_shader;
    public Material lens_shader;    
    
    
    void handleQ1()
    {
        
        
    }
    
    void handleQ2()
    {
        
        
    }
    
    void handleQ3()
    {
        
        
    }
    
    
    
    // Start is called before the first frame update
    void Start()
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
