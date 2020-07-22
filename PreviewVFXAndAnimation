using UnityEngine;

[ExecuteInEditMode]
public class PreviewVFXAndAnimation : MonoBehaviour
{
    public ParticleSystem VFX;
    public Animator Anim;

    public string AnimatorStateName;
    public int AnimatorLayerIndex;
    [Range(0f,3f)]
    public float CurrentTime;

    bool lastAutoPlay = false;        
    public bool AutoPlay = false;
    
    void OnValidate()
    {
        if (VFX)
        {
//            VFX.Simulate(CurrentTime, true, true);
            VFX.time = CurrentTime;
        }
        setAnimationFrame(AnimatorStateName, AnimatorLayerIndex,CurrentTime);
        if (lastAutoPlay != AutoPlay)
        {
            lastAutoPlay = AutoPlay;
            VFX.Simulate(CurrentTime, true, true);
        }
    }

    void Update()
    {
        if (!AutoPlay) return;

        CurrentTime +=Time.unscaledDeltaTime ;
        if (CurrentTime > 2.99f)
        {
            CurrentTime = 0f;
            if (!VFX.isPlaying) VFX.Play();
            VFX.time = CurrentTime;
        }
        setAnimationFrame(AnimatorStateName, AnimatorLayerIndex,CurrentTime);
    }

    private void setAnimationFrame(string animationName, int layer, float normalizedTime)
    {
        if (Anim == null) return;
        
        Anim.speed = 0f;
        Anim.Play(animationName, layer, normalizedTime);
        Anim.Update(Time.deltaTime);
    }
}
