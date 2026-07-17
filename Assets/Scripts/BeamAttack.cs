using System.Threading;
using UnityEngine;
using UnityEngine.VFX;

public class BeamAttack : MonoBehaviour
{
    public VisualEffect vfxGraph;

    private AnimationCurve sharedCurve;
    private float timer = 0f;
    private BoxCollider2D boxCollider;
    private Vector3 originalSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        originalSize = boxCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float normalizedTime = timer / vfxGraph.GetFloat("LifeTime");
        sharedCurve = vfxGraph.GetAnimationCurve("CylinderGrowXY");
        float curveValue = sharedCurve.Evaluate(normalizedTime);
        Vector3 newSize = originalSize;
        newSize.y = curveValue * originalSize.y;
        boxCollider.size = newSize;

    }
}
