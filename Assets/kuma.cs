using UnityEngine;

// もろもろchikinクラスを継承します 必要ない機能がほとんどですが・・・
class Ckuma : chikin
{
    private const float speed = 0.5f;

    public Ckuma(GameObject obj) : base(obj) {
        // playerタグを追従するカメラのアセット入れてるから設定
        myobj.tag = "Player";
    }

    // 回転させてもよかったけどカメラの移動があれになって面倒だった
    public void move(string direction)
    {
        switch (direction)
        {
            case "up":
                myobj.transform.position += new Vector3(0, 0, speed);
                //myobj.transform.rotation = Quaternion.Euler(0,0,0);
                break;
            case "down":
                myobj.transform.position += new Vector3(0, 0, -speed);
                //myobj.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case "right":
                myobj.transform.position += new Vector3(speed, 0, 0);
                //myobj.transform.rotation = Quaternion.Euler(0, 90, 0);

                //myobj.transform.Rotate(0,1,0);
                break;
            case "left":
                myobj.transform.position += new Vector3(-speed, 0, 0);
                //myobj.transform.rotation = Quaternion.Euler(0, -1, 0);

                //myobj.transform.Rotate(0, -1, 0);
                break;

        }
        
    }

    public Vector3 position()
    {
        return myobj.transform.position;
    }
}