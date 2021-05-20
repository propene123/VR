Shader "Custom/Inv"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _c1 ("c1", Float) = -0.25
        _c2 ("c2", Float) = 0.05
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

            fixed4 frag (v2f i) : SV_Target
            {
                float2 xy = 2*(i.uv.xy - float2(0.5f,0.5f));
                float r = length(xy);
                float2 dir;
                if(any(xy)) dir = normalize(xy);
                else dir = float2(0.0f,0.0f);
                                  
                r = r + _c1*pow(r,3) + _c2*pow(r,5);
                  
                xy = r*dir;
                
                xy = (xy/2.0f) + float2(0.5,0.5);
                
                fixed4 col = tex2D(_MainTex, xy);
                return col;
            }
            ENDCG
        }
    }
}
