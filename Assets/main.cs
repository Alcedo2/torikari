using UnityEngine;
using System.Collections.Generic;
using System;

public class main : MonoBehaviour {

    public GameObject chikObj;
    public GameObject kumaObj;
    private List<chikin> chikinList;
    private Ckuma kuma;
	// Use this for initialization
	void Start () {
        // newしてから使うものをnewしとく
        chikinList = new List<chikin>();

        // プレイヤーの熊を作ります
        kuma = new Ckuma(kumaObj);
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

            // 衝突チェック
            float x = kuma.position().x;
            float z = kuma.position().z;
            if (chikinList[i].isClashed(x,z))
            {
                Debug.Log("クマが鶏にダイレクトアタック");
            }
        }


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
        if(Input.GetKeyUp(KeyCode.Space))
        {
            createChiks(0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
            kuma.move("up");
        if (Input.GetKey(KeyCode.RightArrow))
            kuma.move("right");
        if (Input.GetKey(KeyCode.LeftArrow))
            kuma.move("left");
        if (Input.GetKey(KeyCode.DownArrow))
            kuma.move("down");

    }
}
