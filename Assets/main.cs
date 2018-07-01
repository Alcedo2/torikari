using UnityEngine;
using System.Collections.Generic;
using System;

public class main : MonoBehaviour {

    public GameObject chikObj;
    private List<chikin> chikinList;
	// Use this for initialization
	void Start () {
        // リストはnewしてから使う
        chikinList = new List<chikin>();
	}
	
	// Update is called once per frame
	void Update () {
        keyInput();
        objUpdate();
	}

    // オブジェクトを更新
    private void objUpdate()
    {
        for(int i = 0; i < chikinList.Count; i++)
        {
            // ここで死んでる奴は消しときましょう
            if (!chikinList[i].isAlive())
            {
                chikinList.RemoveAt(i);
                continue;
            }
            // 生きてたら動かしましょうね
            chikinList[i].moveRondom();
        }

        // 拡張for文だと削除したときの関係でエラーが出るみたい
        //foreach (chikin chik in chikinList)
        //{
        //    // ここで死んでる奴は消しときましょう
        //    if (!chik.isAlive())
        //    {
        //        chikinList.Remove(chik);
        //        continue;
        //    }
        //    // 生きてたら動かしましょうね
        //    chik.moveRondom();
        //}
    }

    // Instantiateが1MonoBehaviorのメンバだったのでmainで生成する。
    // 制御自体はchikinクラス
    private void createChiks(int x, int y)
    {
        chikin chik;
        // Instantiateで生成したやつを保存します
        chik = new chikin(Instantiate(chikObj, new Vector3 (x,y,0), Quaternion.identity) as GameObject);
        // chikinのリストに入れます
        chikinList.Add(chik);
    }

    // キー入力を監視
    private void keyInput()
    {
        if(Input.GetKeyUp("space"))
        {
            createChiks(0,0);
        }
    }
}
