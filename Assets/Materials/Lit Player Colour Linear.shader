Shader "Ars_Mond/Lit/Casual Colour Linear"
{
    Properties
	{
		_Color("Color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
        }
        Lighting On

        Pass
        {
            Tags
            {
                "LightMode" = "ForwardBase"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct Input
            {
                float4 pos : SV_POSITION;         
            };

            uniform float4 _Color;
         
            Input vert(appdata_full v)
            {
                Input o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag() : COLOR
            {
                float3 color = _Color.xyz;
                return half4(color, 0.5f);
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}