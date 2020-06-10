using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject CrossTable;
    public GameObject ZeroTable;
    public GameObject DrawTable;

    public GameObject CrossMovesFirst;

    private GameObject thisField;

    public GameObject WinningTapToContinueTable;

    private void Start()
    {
        CrossMovesFirst.SetActive(true);
        thisField = Instantiate(GameObject.Find("FieldsPrefabs").GetComponent<AllFieldsPrefabs>().ThreeToThree, Vector3.zero, Quaternion.identity);
        GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn = 1;
    }

    public void Restart()
    {
        GoDefault();
        Start();
    }

    public void GoDefault()
    {
        DestroyCrosses();
        DestroyZeros();
        Destroy(thisField);
        SetAllTablesFalse();
        Field.SetFieldZero();
        Field.FilledCells = 0;
    }

    private void DestroyCrosses()
    {
        GameObject[] Crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (GameObject cross in Crosses)
        {
            Destroy(cross);
        }
    }

    private void DestroyZeros()
    {
        GameObject[] Zeros = GameObject.FindGameObjectsWithTag("Zero");
        foreach (GameObject zero in Zeros)
        {
            Destroy(zero);
        }
    }

    private void SetAllTablesFalse()
    {
        CrossTable.SetActive(false);
        ZeroTable.SetActive(false);
        DrawTable.SetActive(false);
    }

    public void EndGame(string Result)
    {
        GameObject.Find("PlayerSystem").GetComponent<PlayerSystem>().Turn = 0;
        WinningTapToContinueTable.SetActive(true);
        WinningTapToContinueTable.GetComponent<WinningTapToContinueTableScript>().Winner = Result;
    }

    public void CreateEndTable(string Result)
    {
        if (Result == "Cross")
            CrossWin();
        else if (Result == "Zero")
            ZeroWin();
        else if (Result == "Draw")
            Draw();
    }

    private void CrossWin()
    {
        CrossTable.SetActive(true);
    }

    private void ZeroWin()
    {
        ZeroTable.SetActive(true);
    }

    private void Draw()
    {
        DrawTable.SetActive(true);
    }
}
