Shader "Custom/NewSurfaceShader"
{
	Properties
	{
		_BumpAmp("Distortion", range(0,13)) = 10
		_Color("Alpha", Color) = (1,1,1,1)
		_Normal("NormalMap", 2D) = "bump" {}
	}
	SubShader
	{
		Tags{ Queue = Transparent "RenderType" = "Transparent" }
		Lighting Off

		CGPROGRAM
		#pragma surface surf Standard alpha:fade 
		sampler2D _Normal;
		fixed4 _Color;
		float _BumpAmp;

		struct Input
		{
			float2 uv_Normal;
		};
		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			o.Alpha = _Color.a;
			o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Normal) * _BumpAmp);
		}
		ENDCG
	}
	FallBack "Diffuse"
}