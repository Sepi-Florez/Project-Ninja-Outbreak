Shader "Test/Glow"
{
	Properties
	{
		_MainTex("Base (RGBA)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Multiplier("Multiplier", Int) = 1
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" }
		LOD 200
		ZTest Always
		Cull Off
		Blend One One

		CGPROGRAM
		#pragma surface surf Lambert
		sampler2D _MainTex;
		float4 _Color;
		int _Multiplier;

		struct Input 
		{
			float2 uv_MainTex;
			float3 viewDir;
			float3 worldNormal;
		};

		void surf(Input IN, inout SurfaceOutput o) 
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Alpha = _Color.a * pow(abs(dot(normalize(IN.viewDir),
				normalize(IN.worldNormal))),4.0);
			o.Emission = _Color.rgb * o.Alpha * _Multiplier;
		}
		ENDCG
	}
	FallBack "Diffuse"
}