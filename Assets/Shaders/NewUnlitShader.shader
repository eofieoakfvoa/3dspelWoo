Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
        //_Value ("Value", float ) = 1.0,
        _ColorA ("ColorA", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (1,1,1,1)
        _ColorStart ("_ColorStart", Range(0,1)) = 0
        _ColorEnd ("_ColorEnd", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Value;
            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;

            struct appdata // Per-vertex mesh data
            {
                float4 vertex : POSITION; // vertex position
                float3 normals : NORMAL;
                float4 tangent : TANGENT;
                float4 color : COLOR;
                float4 uv0 : TEXCOORD0; // uv coordinates
            };

            struct v2f // Fragment shader input
            {
                float4 vertex : SV_POSITION; // clip space position vafan e clip?? / ifall jag fattar e clip spcae typ att den inte baseras på positionen av objecten och bara sätts på skärmen
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            //Generellt gör man matten i vert och inte i frag, därför att det finns generällt mindre vertices än pixlar
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);
                //o.uv = (v.uv0 + _Offset) * _Scale;
                o.uv = v.uv0;
                return o;
            } //UnityObjectToWorldNormal


            float InverseLerp( float a, float b, float v){
                return (v-a)/(b-a);
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float t = saturate(InverseLerp(_ColorStart, _ColorEnd, i.uv.x));
                t = frac(t);

                float4 outColor = lerp( _ColorA, _ColorB, t);
                return outColor;
                
                //return outColor;
            }
            ENDCG
        }
    }
}
