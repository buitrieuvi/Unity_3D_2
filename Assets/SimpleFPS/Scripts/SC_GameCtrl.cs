using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_GameCtrl : MonoSingleton<SC_GameCtrl>
{
    private int time;
    private int score;
    private int die;


    public SC_GameCtrl(int time, int score, int die)
    {
        this.time = time;
        this.score = score;
        this.die = die;
    }

    public int Time { get => time; set => time = value; }
    public int Score { get => score; set => score = value; }
    public int Die { get => die; set => die = value; }

    public int TangDiem(int soDiemTang) 
    {
        return Score += soDiemTang;
    }


}
