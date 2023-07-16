using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amount_Skill : MonoBehaviour
{
    public Text amount_Kajiki;　//残りの数を表記するテキスト
    public Text amount_Kurage;　//残りの数を表記するテキスト
    public Text amount_Unagi;　//残りの数を表記するテキスト

    public int a_Kajiki; //数を計算する
    public int a_Kurage; //数を計算する
    public int a_Unagi; //数を計算する

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amount_Kajiki.text = "" + a_Kajiki;　//スキルの数を表記するテキストの中身を変更
        amount_Unagi.text = "" + a_Unagi;　//スキルの数を表記するテキストの中身を変更
        amount_Kurage.text = "" + a_Kurage;　//スキルの数を表記するテキストの中身を変更
    }
}
