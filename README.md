# Kaj's Flat Lit Toon MMD Extension
MMD Sphere and Toon Texture supporting shaders based on Flat Lit Toon

Ever wanted to replicate an MMD author's work as accurately as possible in VRChat?  Well now you can.

REQUIRES [Cubed's Unity Shaders](https://github.com/cubedparadox/Cubeds-Unity-Shaders)

## This package contains two shaders: 

**Flat Lit Toon MMD Full:** Supports add/multiply sphere textures, and shadows mesh based on a toon texture.  To achieve an effect similar to Flat Lit Toon's defualt shadowing, use the provided toon01.bmp texture.

**Flat Lit Toon Lite Fade MMD:** Supports all additional features of the MMD Full shader (minus outlines), but renders transparency correctly.

## NOTES:
In Unity, set the Wrap Mode of toon textures to Clamp, otherwise the very dark and very light areas of a surface will incorrectly mix the dark/light ends of a toon texture.

Some sphere textures have the .spa or .sph file extension; you can rename these to .tga to use them in Unity.

## Examples:

![Additive Spheres](https://i.imgur.com/YET4on1.png)

![Multiply Spheres](https://i.imgur.com/Y8iXWxH.png)

![Toon Textures](https://i.imgur.com/SB09gg4.png)
