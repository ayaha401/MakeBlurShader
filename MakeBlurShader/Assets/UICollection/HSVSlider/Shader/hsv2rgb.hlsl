#ifndef HSV2RGB
#define HSV2RGB

    float3 hsv2rgb(float3 hsv)
    {
        float3 rgb;

        if (hsv.y == 0)
        {
            rgb.r = rgb.g = rgb.b = hsv.z;
        } 
        else 
        {
            hsv.x *= 6.0;
            float i = floor (hsv.x);
            float f = hsv.x - i;
            float aa = hsv.z * (1 - hsv.y);
            float bb = hsv.z * (1 - (hsv.y * f));
            float cc = hsv.z * (1 - (hsv.y * (1 - f)));
            if( i < 1 ) {
                rgb.r = hsv.z;
                rgb.g = cc;
                rgb.b = aa;
            } else if( i < 2 ) {
                rgb.r = bb;
                rgb.g = hsv.z;
                rgb.b = aa;
            } else if( i < 3 ) {
                rgb.r = aa;
                rgb.g = hsv.z;
                rgb.b = cc;
            } else if( i < 4 ) {
                rgb.r = aa;
                rgb.g = bb;
                rgb.b = hsv.z;
            } else if( i < 5 ) {
                rgb.r = cc;
                rgb.g = aa;
                rgb.b = hsv.z;
            } else {
                rgb.r = hsv.z;
                rgb.g = aa;
                rgb.b = bb;
            }
        }
        return rgb;
    }
#endif