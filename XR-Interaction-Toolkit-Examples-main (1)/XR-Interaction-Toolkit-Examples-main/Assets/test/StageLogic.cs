using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLogic : MonoBehaviour
{
    private bool IsActivate = false;
    private bool IsClear = false;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private GameObject stage;

    private GameObject nowStage;

    private void Update()
    {
        if (IsActivate && !IsClear && GameManager.StageClearCheck())
        {
            IsClear = true;
            gameObject.GetComponent<AudioSource>().Play();
            particle.Play();
        }
    }

    public void StartStage()
    {
        if (!IsActivate && stage != null)
        {
            nowStage = Instantiate(stage, GameManager.StageOrigin, Quaternion.identity);
            IsActivate = true;
        }
    }

    public void RemoveStage()
    {
        if (IsActivate)
        {
            Destroy(nowStage);
            nowStage = null;
            IsActivate = false;
        }
    }
}
