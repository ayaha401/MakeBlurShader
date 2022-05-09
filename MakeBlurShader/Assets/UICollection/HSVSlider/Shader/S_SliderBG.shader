Shader "Unlit/S_SliderBG"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _Hue ("Hue", Float) = 0
        _Val ("Value", Float) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "IgnoreProjector"="True"
            "PreviewType"="Plane"
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "../Shader/hsv2rgb.hlsl"

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

            sampler2D _MainTex; float4 _MainTex_ST;

            half _Hue, _Val;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(fixed3(hsv2rgb(float3(_Hue, i.uv.x, _Val))), 1.);
                return col;
            }
            ENDCG
        }
    }
}
