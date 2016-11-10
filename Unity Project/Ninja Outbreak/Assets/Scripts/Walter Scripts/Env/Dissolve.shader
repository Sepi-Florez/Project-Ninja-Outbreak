Shader "Custom/Dissolve"
{
	Properties
	{
		_MainTex("Texture (RGB)", 2D) = "white" {}
		_SliceGuide("Slice Guide (RGB)", 2D) = "white" {}
		_SliceAmount("Slice Amount", Range(0.0, 1.0)) = 0.5
	}
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		Cull Off
		CGPROGRAM

		#pragma surface surf Lambert //addshadow
		struct Input
		{
			float2 uv_MainTex;
			float2 uv_SliceGuide;
			float3 worldPos;
			float _SliceAmount;
		};

		sampler2D _MainTex;
		sampler2D _SliceGuide;
		float _SliceAmount;
		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			float2 worldUV = (IN.worldPos.xy + IN.worldPos.z) * 0.25f; 			//worldUV *= float2(2, 1.5f);
			clip(tex2D(_SliceGuide, worldUV).rgb - _SliceAmount);
		}
		ENDCG
	}
	Fallback "Diffuse"
}