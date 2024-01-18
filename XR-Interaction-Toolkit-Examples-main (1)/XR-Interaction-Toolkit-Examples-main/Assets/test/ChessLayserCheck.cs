using System.Collections.Generic;
using UnityEngine;

public class ChessLayserCheck : MonoBehaviour
{
    private int pointCount = 0;
    [SerializeField]
    private bool check = false;
    public bool Check => check;

    [SerializeField]
    private GameObject[] lays;
    public GameObject[] Lays => lays;

    public ParticleSystem particle;

    [SerializeField]
    private Dictionary<LayserPointer, int> level;
    public int Level
    {
        get
        {
            int result = -1;
            foreach (var item in level)
            {
                if (item.Value > result)
                {
                    result = item.Value;
                }
            }
            return result;
        }
    }

    private bool safeSwitch=false;

    private void Start()
    {
        foreach (var lay in lays)
        {
            lay.GetComponent<LayserPointer>().parent = gameObject;
        }
        SetLays(false);
        level = new();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (gameObject.CompareTag("DarkChess") && particle != null)
        {
            if (check)
            {
                if (particle.isStopped)
                {
                    particle.Play();
                }
            }
            else
            {
                if (particle.isPlaying)
                {
                    particle.Stop();
                }
            }
        }
    }

    public void Point(LayserPointer layser, int level)
    {
        if (SelfCheck(layser))
        {
            return;
        }

        if (Level != -1 && Level <= level)//레벨 체크
        {
            return;
        }

        if (!this.level.ContainsKey(layser))//중복 체크
        {
            this.level.Add(layser, level + 1);
        }
        else
        {
            this.level[layser] = level;
        }

        if (this.level.Count == 1)//활성화 체크
        {
            check = true;
            Debug.Log("활성화");
            SetLays(true);
        }
    }

    public void UnPoint(LayserPointer layser)
    {
        if (SelfCheck(layser))
        {
            return;
        }

        if (level.Count == 1)
        {
            check = false;
            Debug.Log("비활성화");
            if (safeSwitch==false)
            {
                safeSwitch = true;
                foreach (var lay in lays)
                {
                    lay.GetComponent<LayserPointer>().Unpoint();
                }
                safeSwitch = false;
            }
            
            SetLays(false);
        }
        level.Remove(layser);
    }

    private void SetLays(bool triger)
    {
        foreach (var lay in lays)
        {
            lay.SetActive(triger);
        }
    }

    private bool SelfCheck(LayserPointer layser)
    {
        foreach (GameObject lay in lays)
        {
            if (lay==layser.gameObject)
            {
                Debug.Log(1);
                return true;
            }
        }
        return false;
    }
}
