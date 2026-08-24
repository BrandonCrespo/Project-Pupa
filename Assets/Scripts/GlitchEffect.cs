using UnityEngine;
using KinoGlitch;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlitchEffect : MonoBehaviour
{
    public DigitalGlitchController DigitalGlitchEffect;
    public AnalogGlitchController AnalogGlitchEffect;
    [SerializeField] private Volume PostProcessVolume;

    private ColorAdjustments ColorAdjustments;
    private float GlitchTimer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PostProcessVolume.profile.TryGet(out ColorAdjustments);
    }

    // Update is called once per frame
    void Update()
    {
        GlitchTimer += Time.deltaTime;
        if (GlitchTimer < 11.0f)
        {
            if (GlitchTimer > 9.0f && GlitchTimer < 10.0f)
            {
                float intensity = GlitchTimer - 9.0f;

                DigitalGlitchEffect.Intensity = intensity;

                AnalogGlitchEffect.ScanLineJitter = intensity;
                AnalogGlitchEffect.VerticalJump = intensity;
                AnalogGlitchEffect.HorizontalShake = intensity;
                AnalogGlitchEffect.ColorDrift = intensity;
                AnalogGlitchEffect.HorizontalRipple = intensity;
            }
            else if (GlitchTimer >= 10.3f && GlitchTimer < 10.6f)
            {
                ColorAdjustments.colorFilter.overrideState = true;
                DigitalGlitchEffect.Intensity = 0;

                AnalogGlitchEffect.ScanLineJitter = 0;
                AnalogGlitchEffect.VerticalJump = 0;
                AnalogGlitchEffect.HorizontalShake = 0;
                AnalogGlitchEffect.ColorDrift = 0;
                AnalogGlitchEffect.HorizontalRipple = 0;
            }
            else if (GlitchTimer >= 10.6f)
            {
                ColorAdjustments.colorFilter.overrideState = false;
            }
        }
    }
}
