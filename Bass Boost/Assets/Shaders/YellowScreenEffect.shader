Shader "Unlit/YellowScreenEffect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseText("Noise Texture", 2D) = "white"{}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _NoiseText;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{

				// sample the texture
				half4 color = (tex2D(_NoiseText, i.textcoord) + _TextureSampleAdd) * i.color;

			color.r = 1;
			color.g = 1;
			color.b = 0.1;

			color.a *= UnityGet2DClipping(i.worldPosition.xy, _ClipRect);

			clip(color.a - 0.001);
				return color;
			}
			ENDCG
		}
	}
}
