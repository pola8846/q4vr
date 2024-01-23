using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField]
    private Material material_lay;
    public static Material Material_lay => instance.material_lay;

    [SerializeField]
    private Material material_lay_start;
    public static Material Material_lay_start => instance.material_lay_start;

    [SerializeField]
    private Vector3 stageOrigin = Vector3.zero;
    public static Vector3 StageOrigin => instance.stageOrigin;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static bool StageClearCheck()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DarkChess"))
        {
            var chessObj = obj.GetComponent<ChessLayserCheck>();
            if (!chessObj.Check)
            {
                return false;
            }
        }

        return true;
    }
}
