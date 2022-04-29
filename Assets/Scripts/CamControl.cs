using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CamControl : MonoBehaviour
{

    void Start()
    {
        var seq = DOTween.Sequence();
        seq.Append(GetComponent<Camera>().DOFieldOfView(29.4f, 1f));
        seq.Append(GetComponent<Camera>().DOFieldOfView(80, 0.1f));
        seq.Append(GetComponent<Camera>().DOFieldOfView(70, 0.2f));
        //seq.Append(GetComponent<Camera>().DOShakeRotation(1f,new Vector3(20,0,0),10));

    }

}
