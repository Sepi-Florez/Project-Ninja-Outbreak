// shadertype=<unity>
// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Cg shading in world space"
{
	Properties
	{
		_Point("player position", Vector) = (0., 0., 0., 1.0)
		_DistanceNear("orb range", Float) = 5.0
		_ColorNear("color near to point", Color) = (1.0, 1.0, 1.0, 1.0)
		_ColorFar("color far from point", Color) = (0.5, 0.5, 0.5, 0.0)
	}

	SubShader
	{
		Pass
		{
		CGPROGRAM

#pragma vertex vert  
#pragma fragment frag 

#include "UnityCG.cginc" 
		// defines _Object2World and _World2Object

		// uniforms corresponding to properties
		uniform float4 _Point;
		uniform float _DistanceNear;
		uniform float4 _ColorNear;
		uniform float4 _ColorFar;

		struct vertexInput
		{
			float4 vertex : POSITION;
		};
		struct vertexOutput
		{
			float4 pos : SV_POSITION;
			float4 position_in_world_space : TEXCOORD0;
		};

		vertexOutput vert(vertexInput input)
		{
			vertexOutput output;

			output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
			output.position_in_world_space = mul(unity_ObjectToWorld, input.vertex);
			return output;
		}

		float4 frag(vertexOutput input) : COLOR
		{
			float dist = distance(input.position_in_world_space,
			_Point);
		// computes the distance between the fragment position 
		// and the position _Point.

			if (dist < _DistanceNear)
			{
				return _ColorNear;
			}
			else
			{
				return _ColorFar;
			}
		}
		ENDCG
		}
	}
}