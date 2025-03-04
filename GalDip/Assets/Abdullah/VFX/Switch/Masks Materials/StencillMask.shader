Shader "Custom/StencillMask"
{
    Properties
    {
        [IntRange] _StencilID ("Mask ID", Range(0,10)) = 0
    }

    SubShader
    {
        Tags
        {
        "RednerType"="Opaque"
        "RenderPipeline"="UniversalPipeline"
        "Queue"="Geometry"
        }

        Pass
        {
        Blend Zero One
        Zwrite off
            Stencil
            {
                //test 1 
                Ref [_StencilID]

                //Test 2 
                Comp Always
                //
                Pass Replace
                //
                Fail Keep

            } 
         }
    }
}
