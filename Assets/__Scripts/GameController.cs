using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject PhysicalField;

    private GameObject _Canvas;

    public GameObject CrossVictoryTablePrefab;
    public GameObject ZeroVictoryTablePrefab;

    private GameObject CrossVictoryTable;
    private GameObject ZeroVictoryTable;

    private void Awake()
    {
        PhysicalField = GameObject.Find("PhysicalField");
        _Canvas = GameObject.Find("Canvas");
    }

    private void Start()
    {
        PhysicalField.GetComponent<FiguresOnField>().SetAllOnFieldZero();
    }

    public void Restart()
    {
        PhysicalField.GetComponent<FiguresOnField>().SetEverythingDefault();
        Destroy(CrossVictoryTable);
        Destroy(ZeroVictoryTable);
    }

    void Update()
    {
        if (PhysicalField.GetComponent<FiguresOnField>().Victory == 1)
        {
            CrossVictoryTable = Instantiate(CrossVictoryTablePrefab, _Canvas.transform);
            PhysicalField.GetComponent<FiguresOnField>().Victory = -1;
        }
        else if (PhysicalField.GetComponent<FiguresOnField>().Victory == 2)
        {
            ZeroVictoryTable = Instantiate(ZeroVictoryTablePrefab, _Canvas.transform);
            PhysicalField.GetComponent<FiguresOnField>().Victory = -1;
        }
    }
}
