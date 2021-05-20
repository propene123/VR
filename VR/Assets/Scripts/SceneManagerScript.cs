using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Question
{
    Q1_Pre_Distortion_Fragment_Shader,
    Q2_LCA_Correction_Fragment_Shader,
    Q3_Pre_Distortion_Mesh_Vertex_Shader
}


public enum Triangles
{
    Thirty_Two,
    One_Hundred_Twenty_Eight,
    Five_Hundred_Twelve
}

[ExecuteAlways]
public class SceneManagerScript : MonoBehaviour
{
    public Question question;
    public Triangles Q3_Mesh_Triangle_Count;
    public bool inverse = false;
    public float c1 = -0.25f;
    public float c2 = 0.05f;
    public float LCA_C1 = 0.1f;
    public float LCA_C2 = -0.05f;
    public Material main_shader;
    public Material lens_shader;    
    public Camera pre_cam;
    
    
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
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Quad Base"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
        }else
        {
            pre_cam.cullingMask |= (1 << LayerMask.NameToLayer("Quad Base"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
            
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens Base"));
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
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Quad Base"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
        }else
        {
            pre_cam.cullingMask |= (1 << LayerMask.NameToLayer("Quad Base"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
            pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
            
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
            Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
            Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens Base"));
        }
    }
    
    void handleQ3()
    {
        main_shader.shader = Shader.Find("Custom/BarrelVec");
        main_shader.SetFloat("_c1",c1);
        main_shader.SetFloat("_c2",c2);
        lens_shader.shader = Shader.Find("Custom/InvVec");
        lens_shader.SetFloat("_c1",c1);
        lens_shader.SetFloat("_c2",c2);
        
        switch (Q3_Mesh_Triangle_Count)
        {
            case Triangles.Thirty_Two:
                if(!inverse)
                {
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Plane 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    
                }else
                {
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    pre_cam.cullingMask |= (1 << LayerMask.NameToLayer("Plane 32"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                }
                break;
            case Triangles.One_Hundred_Twenty_Eight:
                if(!inverse)
                {
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Plane 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    
                }else
                {
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    pre_cam.cullingMask |= (1 << LayerMask.NameToLayer("Plane 128"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                }
                break;
            case Triangles.Five_Hundred_Twelve:
                if(!inverse)
                {
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Plane 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    
                }else
                {
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
                    pre_cam.cullingMask |= (1 << LayerMask.NameToLayer("Plane 512"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    pre_cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 512"));
                    
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Quad Base"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 128"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Plane 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 32"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens 128"));
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Lens 512"));
                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Lens Base"));
                }
                break;
        }
        
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
