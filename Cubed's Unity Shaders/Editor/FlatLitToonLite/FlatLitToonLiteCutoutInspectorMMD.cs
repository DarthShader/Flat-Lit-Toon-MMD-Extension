﻿using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CubedsUnityShaders
{
    public class FlatLitToonLiteCutoutInspectorMMD : ShaderGUI
    {
        public enum CullingMode
        {
            Off,
            Front,
            Back
        }

        MaterialProperty mainTexture;
        MaterialProperty color;
        MaterialProperty colorMask;
        MaterialProperty sphereAddTexture;
        MaterialProperty sphereAddIntensity;
        MaterialProperty sphereMulTexture;
        MaterialProperty sphereMulIntensity;
        //MaterialProperty shadow;
        MaterialProperty toonTex;
        MaterialProperty emissionMap;
        MaterialProperty emissionColor;
        MaterialProperty normalMap;
        MaterialProperty alphaCutoff;
        MaterialProperty cullingMode;

        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            { //Find Properties
                mainTexture = FindProperty("_MainTex", properties);
                color = FindProperty("_Color", properties);
                colorMask = FindProperty("_ColorMask", properties);
                sphereAddTexture = FindProperty("_SphereAddTex", properties);
                sphereAddIntensity = FindProperty("_SphereAddIntensity", properties);
                sphereMulTexture = FindProperty("_SphereMulTex", properties);
                sphereMulIntensity = FindProperty("_SphereMulIntensity", properties);
                //shadow = FindProperty("_Shadow", properties);
                toonTex = FindProperty("_ToonTex", properties);
                emissionMap = FindProperty("_EmissionMap", properties);
                emissionColor = FindProperty("_EmissionColor", properties);
                normalMap = FindProperty("_BumpMap", properties);
                alphaCutoff = FindProperty("_Cutoff", properties);
                cullingMode = FindProperty("_Cull", properties);
            }

            //Shader Properties GUI
            EditorGUIUtility.labelWidth = 0f;

            EditorGUI.BeginChangeCheck();
            {
                EditorGUI.showMixedValue = cullingMode.hasMixedValue;
                var cMode = (CullingMode)cullingMode.floatValue;

                EditorGUI.BeginChangeCheck();
                cMode = (CullingMode)EditorGUILayout.Popup("Culling Mode", (int)cMode, Enum.GetNames(typeof(CullingMode)));
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo("Rendering Mode");
                    cullingMode.floatValue = (float)cMode;
                }
                EditorGUI.showMixedValue = false;
                EditorGUILayout.Space();

                materialEditor.TexturePropertySingleLine(new GUIContent("Main Texture", "Main Color Texture (RGB)"), mainTexture, color);
                EditorGUI.indentLevel += 1;
                materialEditor.TexturePropertySingleLine(new GUIContent("Color Mask", "Masks Color Tinting (G)"), colorMask);
                EditorGUI.indentLevel -= 1;

                materialEditor.TexturePropertySingleLine(new GUIContent("Additive Sphere Texture"), sphereAddTexture);
                materialEditor.ShaderProperty(sphereAddIntensity, "Intensity", 2);
                materialEditor.TexturePropertySingleLine(new GUIContent("Multiply Sphere Texture"), sphereMulTexture);
                materialEditor.ShaderProperty(sphereMulIntensity, "Intensity", 2);
                materialEditor.TexturePropertySingleLine(new GUIContent("Toon Texture"), toonTex);
                materialEditor.TexturePropertySingleLine(new GUIContent("Normal Map", "Normal Map (RGB)"), normalMap);
                materialEditor.TexturePropertySingleLine(new GUIContent("Emission", "Emission (RGB)"), emissionMap, emissionColor);
                EditorGUI.BeginChangeCheck();
                materialEditor.TextureScaleOffsetProperty(mainTexture);
                if (EditorGUI.EndChangeCheck())
                {
                    emissionMap.textureScaleAndOffset = mainTexture.textureScaleAndOffset;
                }

                EditorGUILayout.Space();
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(alphaCutoff, "Alpha Cutoff");

                //EditorGUILayout.Space();
                //materialEditor.ShaderProperty(shadow, "Shadow");
            }
            EditorGUI.EndChangeCheck();

        }
    }
}
