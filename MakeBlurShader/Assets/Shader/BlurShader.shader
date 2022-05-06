Shader "Unlit/BlurShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Blur ("Blur", float) = 10.0
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
            sampler2D _GrabTexture; fixed4 _GrabTexture_TexelSize;
            float _Blur;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float blur = max(1., _Blur);
                float weightTotal=0.;
                fixed4 col=0.;

                [loop]
                for(float x = -blur; x <= blur; x += 1)
                {
                    float dist = abs(x/blur);
                    float weight = exp(-.5*pow(dist,2.)*5.);
                    weightTotal += weight;
                    col+=tex2Dproj(_GrabTexture, i.grabPos+float4(x*_GrabTexture_TexelSize.x, 0., 0., 0.))*weight;
                }
                col /= weightTotal;

                return col;
            }
            ENDCG
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
            sampler2D _GrabTexture; fixed4 _GrabTexture_TexelSize;
            float _Blur;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float blur = max(1., _Blur);
                float weightTotal=0.;
                fixed4 col=0.;

                [loop]
                for(float y = -blur; y <= blur; y += 1)
                {
                    float dist = abs(y/blur);
                    float weight = exp(-.5*pow(dist,2.)*5.);
                    weightTotal += weight;
                    col+=tex2Dproj(_GrabTexture, i.grabPos+float4(0., y*_GrabTexture_TexelSize.y, 0., 0.))*weight;
                }
                col /= weightTotal;

                return col;
            }
            ENDCG
        }
    }
}
