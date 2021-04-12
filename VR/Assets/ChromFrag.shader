Shader "Hidden/ChromFrag"
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
                float4 clips : TEXCOORD1;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.clips = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                float c1 = 2.0f;
                float c2 = 2.0f;
                float2 xy = i.clips.xy;
                fixed4 res;
                
                float theta = atan2(xy.y,xy.x);
                float r = sqrt((xy.x*xy.x)+(xy.y*xy.y));
                
                r = (c1*pow(r,2)+c2*pow(r,4)+pow(c1,2)*pow(r,4)+pow(c2,2)*pow(r,8)+2*c1*c2*pow(r,6))/(1+4*c1*pow(r,2)+6*c2*pow(r,4));
                
                xy.x = r * cos(theta);
                xy.y = r * sin(theta);
                
                xy = (xy/2.0f) + float2(0.5,0.5);
                
                fixed4 col = tex2D(_MainTex, xy);
                res.r = col.r;
                
                c1 = 2.25f;
                c2 = 2.25f;
                xy = i.clips.xy;
                theta = atan2(xy.y,xy.x);
                r = sqrt((xy.x*xy.x)+(xy.y*xy.y));
                
                r = (c1*pow(r,2)+c2*pow(r,4)+pow(c1,2)*pow(r,4)+pow(c2,2)*pow(r,8)+2*c1*c2*pow(r,6))/(1+4*c1*pow(r,2)+6*c2*pow(r,4));
                
                xy.x = r * cos(theta);
                xy.y = r * sin(theta);
                
                xy = (xy/2.0f) + float2(0.5,0.5);
                
                col = tex2D(_MainTex, xy);
                res.g = col.g;
                
                c1 = 2.5f;
                c2 = 2.5f;
                xy = i.clips.xy;
                theta = atan2(xy.y,xy.x);
                r = sqrt((xy.x*xy.x)+(xy.y*xy.y));
                
                r = (c1*pow(r,2)+c2*pow(r,4)+pow(c1,2)*pow(r,4)+pow(c2,2)*pow(r,8)+2*c1*c2*pow(r,6))/(1+4*c1*pow(r,2)+6*c2*pow(r,4));
                
                xy.x = r * cos(theta);
                xy.y = r * sin(theta);
                
                xy = (xy/2.0f) + float2(0.5,0.5);
                
                col = tex2D(_MainTex, xy);
                res.b = col.b;
                res.a = 1.0f;
                
                return res;
            }
            ENDCG
        }
    }
}
