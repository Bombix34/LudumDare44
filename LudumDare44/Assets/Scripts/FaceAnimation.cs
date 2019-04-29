using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimation : MonoBehaviour
{
    [SerializeField]
    Animator breatheAnim;

    [SerializeField]
    Animator swhinkAnim;
    float swhinkChrono;

    bool isStop = false;

    void Start()
    {
        ResetSwhinkChrono();
        breatheAnim.speed = Random.Range(0.85f, 1.1f);
      //  LaunchAnim();
    }

    void Update()
    {
        if (isStop)
            return;
        swhinkChrono -= Time.deltaTime;
        if(swhinkChrono<=0)
        {
            swhinkAnim.SetTrigger("Swhink");
            ResetSwhinkChrono();
        }
    }

    public void ResetSwhinkChrono()
    {
        swhinkChrono = Random.Range(6f, 10f);
    }

    public void StopAnim()
    {
        isStop = true;
        breatheAnim.SetBool("Breathe", false);
        breatheAnim.speed=0f;
    }

    public void LaunchAnim()
    {
        isStop = false;
        breatheAnim.SetBool("Breathe", true);
    }
}
