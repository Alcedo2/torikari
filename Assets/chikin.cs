using UnityEngine;

public class chikin
{
    // いじらないやつはとりあえずprivate(継承して使いたい場合protected)で宣言
    protected GameObject myobj;

    // 地面の枠のサイズ 基本変えないからprivate
    private const int H = 50, W = 50;

    // 生きてる？
    protected bool alive;

    // 移動量
    protected float delta = 1;

    // 衝突マージン
    private const int margin = 10;

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

    // 衝突チェック
    public bool isClashed(float x, float z)
    {
        Vector3 positoin = myobj.transform.position;
        if(positoin.x - margin < x && x < positoin.x + margin 
            && positoin.z - margin < z && z < positoin.z + margin)
        {
            // 熊に殺されちゃった
            alive = false;
            death();
            return true;
        }

        return false;
    }

    // alive自体をpublicにして直接参照してもいいんだけど
    // クラスの変数はグループ開発ではprivateが無難なのでここでもこの面倒なことやってます
    public bool isAlive()
    {
        return alive;
    }

    protected void death()
    {
        GameObject.Destroy(myobj);
    }
}
