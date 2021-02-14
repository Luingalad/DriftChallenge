using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPartController : MonoBehaviour
{
    void Start()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        tag = "Untagged";
        LeanTween.moveLocalY(gameObject, -20, 5).setEaseOutSine().setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
