using UnityEngine;

public class chikin
{
    // いじらないやつはとりあえずprivateで宣言
    private GameObject myobj;

    // 地面の枠のサイズ
    private const int H = 50, W = 50;

    // 生きてる？
    private bool alive;

    // 移動量
    private float delta = 1;

    // コンストラクタ　chikinオブジェクトを生成したときに呼び出される関数で要は初期化
    // 引数を変えることで複数作ることも出来るよ
    public chikin(GameObject obj)
    {
        myobj = obj;
        alive = true;
    }

    // ランダムに移動させる
    public void moveRondom()
    {
        Vector3 position = new Vector3(Random.Range(-delta, delta),0, Random.Range(-delta, delta));
        myobj.transform.position += position;

        // はみ出たら消す
        if(myobj.transform.position.x > W || myobj.transform.position.z > H)
        {
            alive = false;
            GameObject.Destroy(myobj);
        }
            

    }

    // alive自体をpublicにして直接参照してもいいんだけど
    // クラスの変数はグループ開発ではprivateが無難なのでここでもこの面倒なことやってます
    public bool isAlive()
    {
        return alive;
    }

    private void death()
    {
        GameObject.Destroy(myobj);
    }
}
