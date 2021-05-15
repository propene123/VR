Shader "Hidden/BarrelVec"
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
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float c1 = -0.25f;
                float c2 = 0.05f;
                float2 xy = o.vertex.xy;
                
                float theta = atan2(xy.y,xy.x);
                float r = sqrt((xy.x*xy.x)+(xy.y*xy.y));
                
                r = r + c1*pow(r,3) + c2*pow(r,5);
                                
                xy.x = r * cos(theta);
                xy.y = r * sin(theta);
                
                o.vertex.xy = xy;                
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
