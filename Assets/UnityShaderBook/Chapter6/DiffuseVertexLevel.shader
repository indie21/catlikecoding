// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UnityShaderBook/Chapter6/DiffuseVertexLevel" {
    // Properties {
    //     _Diffuse ("Diffuse", Color) = (1,1,1,1)
    // }

    // SubShader {
    //     Pass {
    //         Tags { "LightMode" = "ForwardBase" }

    //         CGPROGRAM
    //         #pragma vertex vert
    //         #pragma fragment frag

    //         #include "Lighting.cginc"
    //         fixed _Diffuse;

    //         struct a2v {
    //             float4 vertex : POSITION;
    //             float3 normal : NORMAL;
    //         }

    //         struct v2f {
    //             float4 pos : SV_POSITION;
    //             fixed3 clolor : COLOR;
    //         }

    //         v2f vert(a2v v) {
    //             v2f o;

    //             // tranform the vertex from object space to projection space
    //             o.pos = UnityObjectToClipPos(v.vertex);
    //             fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

    //         }

    //         ENDCG
    //     }
    // }
}
