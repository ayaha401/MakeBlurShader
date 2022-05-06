Shader "Unlit/BlurShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Shift ("Shift", Range(0.0, 1.0))      = 0
    }
    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
            "IgnoreProjector"="True"
            "PreviewType"="Plane"
        }

        GrabPass
        {

        }

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
                float4 grabPos : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex; float4 _MainTex_ST;
            sampler2D _GrabTexture;
            float _Shift;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2Dproj(_GrabTexture, i.grabPos + _Shift);
                return col;
            }
            ENDCG
        }
    }
}
