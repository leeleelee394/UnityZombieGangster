using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvases : MonoBehaviour
{
    [SerializeField]
    private PlayCanvas playCanvas;
    [SerializeField]
    private DieCanvas dieCanvas;

    public void PlayerDie()
    {
        ManagerClass.Instance.SaveKillDataToJson();
        playCanvas.Hide();
        dieCanvas.Show();
    }
}
