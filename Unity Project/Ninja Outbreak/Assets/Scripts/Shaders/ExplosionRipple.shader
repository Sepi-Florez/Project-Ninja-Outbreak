Shader "Custom/ExplosionRipple"
{
	Properties
	{
		_BumpAmt  ("Distortion", range (0,128)) = 10
		_MainTex ("Tint Color (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_BumpMap ("Normalmap", 2D) = "bump" {}
	}
	Category
	{
		Lighting Off
		Cull back
		Blend SrcAlpha OneMinusSrcAlpha
		Tags{ Queue = Transparent "RenderType" = "Transparent"}

		SubShader
		{
			// This pass grabs the screen behind the object into a texture.
			// We can access the result in the next pass as _GrabTexture
			GrabPass
			{
				Tags { "LightMode" = "Always" }
			}
			Pass
			{
				Tags { "LightMode" = "Always" }
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fog
				#include "UnityCG.cginc"

				struct appdata_t
				{
					float4 vertex : POSITION;
					float2 texcoord: TEXCOORD0;
				};

				struct v2f
				{
					float4 vertex : SV_POSITION;
					float4 uvgrab : TEXCOORD0;
					float2 uvbump : TEXCOORD1;
					float2 uvmain : TEXCOORD2;
					UNITY_FOG_COORDS(3)
				};

				float _BumpAmt;
				float4 _BumpMap_ST;
				float4 _MainTex_ST;
				float4 _Color;

				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					#if UNITY_UV_STARTS_AT_TOP
					float scale = -1.0;
					#else
					float scale = 1.0;
					#endif
					o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
					o.uvgrab.zw = o.vertex.zw;
					o.uvbump = TRANSFORM_TEX( v.texcoord, _BumpMap );
					o.uvmain = TRANSFORM_TEX( v.texcoord, _MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}
				sampler2D _GrabTexture;
				float4 _GrabTexture_TexelSize;
				sampler2D _BumpMap;
				sampler2D _MainTex;

				half4 frag (v2f i) : SV_Target
				{
					// calculate perturbed coordinates
					half2 bump = UnpackNormal(tex2D( _BumpMap, i.uvbump )).rg; // we could optimize this by just reading the x & y without reconstructing the Z
					float2 offset = bump * _BumpAmt * _GrabTexture_TexelSize.xy;
					#ifdef UNITY_Z_0_FAR_FROM_CLIPSPACE //to handle recent standard asset package on older version of unity (before 5.5)
						i.uvgrab.xy = offset * UNITY_Z_0_FAR_FROM_CLIPSPACE(i.uvgrab.z) + i.uvgrab.xy;
					#else
						i.uvgrab.xy = offset * i.uvgrab.z + i.uvgrab.xy;
					#endif
	
					half4 col = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(i.uvgrab));
					half4 tint = tex2D(_MainTex, i.uvmain);
					col *= tint;
					col *= _Color;
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
			ENDCG
			}
		}
		SubShader
		{
			Blend DstColor Zero
			Pass
			{
				SetTexture [_MainTex] {	combine texture }
			}
		}
	}
}