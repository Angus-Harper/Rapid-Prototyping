using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenFun : JMC
{
    public GameObject player;
    public float moveDistance = 3;
    public float tweenTime = 0.5f;
    public Ease moveEase;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.transform.DOMoveZ(player.transform.position.z + moveDistance, tweenTime).SetEase(moveEase);
            DoEffects();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.transform.DOMoveZ(player.transform.position.z - moveDistance, tweenTime).SetEase(moveEase);
            DoEffects();
        }
    }

    void DoEffects()
    {
        ChangeColour();
        CameraShake();
        ChangeScale();
    }

    void ChangeScale()
    {
        //player.transform.DOPunchScale(Vector3.one * 2, tweenTime);
        player.transform.DOScale(Vector3.one * 2, tweenTime/2).OnComplete(()=> player.transform.DOScale(Vector3.one, tweenTime/2));
    }

    void ChangeColour()
    {
        player.GetComponent<Renderer>().material.DOColor(GetRandomColour(), tweenTime);
    }

    void CameraShake()
    {
        Camera.main.DOShakePosition(tweenTime * 2, 1);
    }
}
