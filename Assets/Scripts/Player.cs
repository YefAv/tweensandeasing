using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    private bool isPlaying = false;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(Vector3.left);

            if (Input.GetKeyDown(KeyCode.RightArrow)) Move(Vector3.right);

            if (Input.GetKeyDown(KeyCode.DownArrow)) Move(Vector3.back);

            if (Input.GetKeyDown(KeyCode.UpArrow)) Move(Vector3.forward);
        }
    }

    private void Move(Vector3 displacement) {
        isPlaying = true;
        float duration = 0.5f;
        Vector3 endPos = transform.position + displacement;

        Vector3 midPos = Vector3.Lerp(transform.position, endPos, 0.5f);
        midPos.y = 1;


        var myTranslationSeq = DOTween.Sequence();
        myTranslationSeq.Append(transform.DOMove(midPos, duration*0.5f));
        myTranslationSeq.Append(transform.DOMove(endPos, duration*0.5f));


        var sequenceMia = DOTween.Sequence();

        sequenceMia.Append(transform.DOScaleY(0.2f, duration*0.5f));
        sequenceMia.Append(transform.DOScaleY(1f, duration * 0.5f));


        myTranslationSeq.onComplete += () => isPlaying=false;
    }
}
