using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelector : MonoBehaviour
{
    public void SetDifficultySelected(int diffilcutySelected)
    { 
        if (diffilcutySelected > 3 || diffilcutySelected < 1) diffilcutySelected = 2;
        DifficultyHolder.instance.SetDifficulty(diffilcutySelected);
    }
}
