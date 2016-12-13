// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-9551-RGB,custl-9465-OUT;n:type:ShaderForge.SFN_Slider,id:3063,x:31180,y:33281,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:8195,x:31337,y:33448,varname:node_8195,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:4862,x:31497,y:33367,varname:node_4862,prsc:2|A-3063-OUT,B-8195-OUT;n:type:ShaderForge.SFN_Vector1,id:5738,x:31497,y:33517,varname:node_5738,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:5833,x:31665,y:33429,varname:node_5833,prsc:2|A-4862-OUT,B-5738-OUT;n:type:ShaderForge.SFN_Exp,id:6718,x:31836,y:33429,varname:node_6718,prsc:2,et:1|IN-5833-OUT;n:type:ShaderForge.SFN_HalfVector,id:6213,x:31665,y:33275,varname:node_6213,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:4264,x:31665,y:33136,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:4024,x:31665,y:33026,varname:node_4024,prsc:2;n:type:ShaderForge.SFN_Dot,id:7677,x:31872,y:33058,varname:node_7677,prsc:2,dt:1|A-4024-OUT,B-4264-OUT;n:type:ShaderForge.SFN_Dot,id:3158,x:31872,y:33231,varname:node_3158,prsc:2,dt:1|A-4264-OUT,B-6213-OUT;n:type:ShaderForge.SFN_Power,id:324,x:32067,y:33350,cmnt:Specular Light,varname:node_324,prsc:2|VAL-3158-OUT,EXP-6718-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4392,x:32067,y:33250,ptovrint:False,ptlb:Bands,ptin:_Bands,varname:_Bands,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Posterize,id:1473,x:32305,y:33289,varname:node_1473,prsc:2|IN-324-OUT,STPS-4392-OUT;n:type:ShaderForge.SFN_Posterize,id:2726,x:32305,y:33158,varname:node_2726,prsc:2|IN-7677-OUT,STPS-4392-OUT;n:type:ShaderForge.SFN_Color,id:286,x:32305,y:32998,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9041,x:32510,y:32987,cmnt:Diffuse Light,varname:node_9041,prsc:2|A-286-RGB,B-2726-OUT;n:type:ShaderForge.SFN_AmbientLight,id:5638,x:32510,y:33107,varname:node_5638,prsc:2;n:type:ShaderForge.SFN_Add,id:3650,x:32806,y:33118,varname:node_3650,prsc:2|A-9041-OUT,B-5638-RGB,C-1473-OUT;n:type:ShaderForge.SFN_LightColor,id:3841,x:32806,y:32985,varname:node_3841,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:3959,x:32806,y:32852,varname:node_3959,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9465,x:32990,y:32985,varname:node_9465,prsc:2|A-3959-OUT,B-3841-RGB,C-3650-OUT;n:type:ShaderForge.SFN_Color,id:9551,x:32974,y:32640,ptovrint:False,ptlb:Emmision,ptin:_Emmision,varname:node_9551,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;proporder:3063-4392-286-9551;pass:END;sub:END;*/

Shader "Shader Forge/GameShader" {
    Properties {
        _Gloss ("Gloss", Range(0, 1)) = 1
        _Bands ("Bands", Float ) = 3
        _Color ("Color", Color) = (1,1,1,1)
        _Emmision ("Emmision", Color) = (0,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Gloss;
            uniform float _Bands;
            uniform float4 _Color;
            uniform float4 _Emmision;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = _Emmision.rgb;
                float3 finalColor = emissive + (attenuation*_LightColor0.rgb*((_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * _Bands) / (_Bands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((_Gloss*10.0)+1.0))) * _Bands) / (_Bands - 1)));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Gloss;
            uniform float _Bands;
            uniform float4 _Color;
            uniform float4 _Emmision;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = (attenuation*_LightColor0.rgb*((_Color.rgb*floor(max(0,dot(lightDirection,normalDirection)) * _Bands) / (_Bands - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((_Gloss*10.0)+1.0))) * _Bands) / (_Bands - 1)));
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
