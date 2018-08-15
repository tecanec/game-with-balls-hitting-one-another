Shader "Unlit/BoostPad"
{
	Properties
	{
		_LightColor("Light", Color) = (1, 1, 1, 0)
		_DarkColor("Dark", Color) = (0, 0, 0, 0)
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

			float4 _LightColor;
			float4 _DarkColor;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float x = abs(i.uv.x - 0.5f);
				float y = i.uv.y - _Time.y;
				float val = frac(x + y);

				fixed4 col = (val < 0.5f) ? _LightColor : _DarkColor;
				if (frac(y * 10) < 0.1) col *= 0.5f;

				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
