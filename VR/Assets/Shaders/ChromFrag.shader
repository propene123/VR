Shader "Custom/ChromFrag"
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

            float2 helpfulConv(float2 pos)
            {
                return (pos/2) + float2(0.5f,0.5f);
            }
            
            float _c1;
            float _c2;
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 xy = 2*(i.uv.xy - float2(0.5f,0.5f));
                float r = length(xy);
                
                float off = (_c1*pow(r,2)+_c2*pow(r,4)+pow(_c1,2)*pow(r,4)+pow(_c2,2)*pow(r,8)+2*_c1*_c2*pow(r,6))/(1+4*_c1*pow(r,2)+6*_c2*pow(r,4));                
                float c1 = -_c1;
                float c2 = -_c2;
                float b_off = (c1*pow(r,2)+c2*pow(r,4)+pow(c1,2)*pow(r,4)+pow(c2,2)*pow(r,8)+2*c1*c2*pow(r,6))/(1+4*c1*pow(r,2)+6*c2*pow(r,4));                
                float red = tex2D(_MainTex, helpfulConv(xy-xy*off)).r;
                float b = tex2D(_MainTex, helpfulConv(xy-xy*b_off)).b;
                float g = tex2D(_MainTex, helpfulConv(xy)).g;
                
                
                return fixed4(red,g,b,1.0f);
            }
            ENDCG
        }
    }
}
