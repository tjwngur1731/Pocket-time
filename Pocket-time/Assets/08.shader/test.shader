Shader "Custom/test"
{
    Properties
    {
      _R("R",Range(0,1)) = 0.5
      _G("G",Range(0,1)) = 0.5
      _B("B",Range(0,1)) = 0.5
      _Bright("밝기",Range(-1,1))= -1
        _CT("속도조절",float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0


        float _R;
        float _G;
        float _B;
        float _Bright;
        float _CT;
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

    
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = float3(_R, _G, _B) + saturate(_Bright*sin(_Time.y*_CT));
           // o.Emission = float3(0, 1, 0);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
