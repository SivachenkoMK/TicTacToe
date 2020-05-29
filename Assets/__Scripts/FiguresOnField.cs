using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiguresOnField : MonoBehaviour
{
    public int[,] Field = new int[3, 3]; // Высота, длина
    // 1 - крест, 2 - ноль
    public int Victory = 0;

    public void SetVictoryZero()
    {
        Victory = 0;
    }

    public void SetAllOnFieldZero()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Field[i, j] = 0;
            }
        }
    }

    public void SetEverythingDefault()
    {
        SetVictoryZero();
        SetAllOnFieldZero();
    }

    private void Update()
    {
        if (Victory != -1)
            CheckForVictory();
    }

    private void CheckForVictory()
    {
        CheckForVerticals();
        CheckForHorizontals();
        CheckForDiagonals();
    }

    private void CheckForHorizontals()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Field[i, 0] == Field[i, 1] && Field[i, 1] == Field[i, 2])
            {
                switch(Field[i, 0])
                {
                    case (1):
                        {
                            CrossWin();
                            break;
                        }
                    case (2):
                        {
                            ZeroWin();
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
        }
    }

    private void CheckForVerticals()
    {
        for (int j = 0; j < 3; j++)
        {
            if (Field[0, j] == Field[1, j] && Field[1, j] == Field[2, j])
            {
                switch (Field[0, j])
                {
                    case (1):
                        {
                            CrossWin();
                            break;
                        }
                    case (2):
                        {
                            ZeroWin();
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
        }
    }

    private void CheckForDiagonals()
    {
        if ((Field[0, 0] == Field[1, 1] && Field[1, 1] == Field[2, 2]) || (Field[2, 0] == Field[1, 1] && Field[1, 1] == Field[0, 2]))
        {
            switch(Field[1, 1])
            {
                case (1):
                    {
                        CrossWin();
                        break;
                    }
                case (2):
                    {
                        ZeroWin();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    private void CrossWin()
    {
        Victory = 1;
        Destroy(GameObject.FindGameObjectWithTag("MainField"));
    }

    private void ZeroWin()
    {
        Victory = 2;
        Destroy(GameObject.FindGameObjectWithTag("MainField"));
    }
}
