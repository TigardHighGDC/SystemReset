Shader "Main Cell" {
    Properties {
        [Header(Base Parameters)]
        _Color ("Tint", Color) = (0, 0, 0, 1)
        _MainTex ("Texture", 2D) = "white" {}
        [HDR] _Emission ("Emission", color) = (0, 0, 0, 1)

        [HDR]
		_SpecularColor("Specular Color", Color) = (0.9, 0.9, 0.9, 1)
		// Controls the size of the specular reflection.
		_Glossiness("Glossiness", Float) = 32
		[HDR]
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimAmount("Rim Amount", Range(0, 1)) = 0.716
		// Control how smoothly the rim blends when approaching unlit
		// parts of the surface.
		_RimThreshold("Rim Threshold", Range(0, 1)) = 0.1		
    }
    SubShader {
        Tags{ "RenderType"="Opaque" "Queue"="Geometry"}

        CGPROGRAM

        #pragma surface surf Stepped fullforwardshadows
        #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;
        half3 _Emission;

        float4 _SpecularColor;
        float _Glossiness;		

        float4 _RimColor;
        float _RimAmount;
        float _RimThreshold;	

        float3 worldPos;

        float4 LightingStepped(SurfaceOutput s, float3 lightDir, half3 viewDir, float shadowAttenuation){
            float shadow = shadowAttenuation;
            
            s.Normal=normalize(s.Normal);
            
            float diff = dot(s.Normal, lightDir);
            
            float towardsLightChange = fwidth(diff);
            float lightIntensity = smoothstep(0, towardsLightChange, diff);
            float3 diffuse = _LightColor0.rgb * lightIntensity * s.Albedo;

            float diffussAvg = (diffuse.r + diffuse.g + diffuse.b) / 3;

            float3 halfVector = normalize(viewDir + lightDir);
            float NdotH = dot(s.Normal, halfVector);
            float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
            float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
            float3 specular = specularIntensitySmooth * _SpecularColor.rgb * diffussAvg;

            float rimDot = 1 - dot(viewDir, s.Normal);

            float rimIntensity = rimDot * pow(dot(lightDir, s.Normal), _RimThreshold);
            rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
            float3 rim = rimIntensity * _RimColor.rgb * diffussAvg;
            
            float4 color;
            color.rgb = (diffuse + specular + rim)  * shadow;
            color.a = s.Alpha;
            return color;
        }

        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf (Input i, inout SurfaceOutput o) {
            worldPos = i.worldPos;
            fixed4 col = tex2D(_MainTex, i.uv_MainTex);
            col *= _Color;
            o.Albedo = col.rgb;
            o.Alpha = col.a;

            o.Emission = _Emission;
        }
        ENDCG
    }
    FallBack "Standard"
}