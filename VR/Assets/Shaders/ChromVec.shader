Shader "Custom/ChromVec"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
                float2 blue : TEXCOORD1;
                float2 red : TEXCOORD2;
            };
            
            float2 helpfulConv(float2 pos)
            {
                return (pos/2) + float2(0.5f,0.5f);
            }
            
            sampler2D _MainTex;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float c1 = -0.25f;
                float c2 = 0.05f;
                float2 xy = 2*(v.uv.xy - float2(0.5f,0.5f));
                float r = length(xy);
                
                float off = (c1*pow(r,2)+c2*pow(r,4)+pow(c1,2)*pow(r,4)+pow(c2,2)*pow(r,8)+2*c1*c2*pow(r,6))/(1+4*c1*pow(r,2)+6*c2*pow(r,4));                
                c1 = -0.1f;
                c2 = 0.05f;
                float b_off = (c1*pow(r,2)+c2*pow(r,4)+pow(c1,2)*pow(r,4)+pow(c2,2)*pow(r,8)+2*c1*c2*pow(r,6))/(1+4*c1*pow(r,2)+6*c2*pow(r,4));                
                
                o.red = helpfulConv(xy-xy*off);
                o.blue = helpfulConv(xy-xy*b_off);
                
                o.uv = v.uv;
                return o;
            }

            

            fixed4 frag (v2f i) : SV_Target
            {
                float red = tex2D(_MainTex, i.red).r;
                float b = tex2D(_MainTex, i.blue).b;
                float g = tex2D(_MainTex, i.uv).g;
                
                return fixed4(red,g,b,1.0f);
            }
            ENDCG
        }
    }
}
