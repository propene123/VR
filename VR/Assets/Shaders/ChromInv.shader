Shader "Custom/ChromInv"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _c1 ("c1", Float) = 0.1
        _c2 ("c2", Float) = -0.05
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _c1;
            float _c2;
            

            float2 helpfulConv(float2 pos)
            {
                return (pos/2) + float2(0.5f,0.5f);
            }
            
            float2 pol2cart(float dist, float angle)
            {
                return float2(dist*cos(angle), dist*sin(angle));
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 xy = 2*(i.uv.xy - float2(0.5f,0.5f));
                
                
                float theta = atan2(xy.y,xy.x);
                float r = sqrt((xy.x*xy.x)+(xy.y*xy.y));
                
                float off = r + _c1*pow(r,3) + _c2*pow(r,5);
                float c1 = -_c1;
                float c2 = -_c2;
                float b_off = r + c1*pow(r,3) + c2*pow(r,5);               
 
                 
                float red = tex2D(_MainTex, helpfulConv(pol2cart(off,theta))).r;
                float b = tex2D(_MainTex, helpfulConv(pol2cart(b_off,theta))).b;
                float g = tex2D(_MainTex, helpfulConv(xy)).g;
                
                
                return fixed4(red,g,b,1.0f);
            }
            ENDCG
        }
    }
}
