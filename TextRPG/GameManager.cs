using TextRPG;
using System.Threading.Tasks;
using System;

class GameManager
{
    private static Action preLoad;

    static void Main()
    {

        StartScene startScene = new StartScene();

        Player player= new Player();

        Stage stage = new Stage();

        Shop shop = new Shop();

        preLoad += shop.SetBasicItem;   // 미리 로드해둘 내용을 preLoad에 저장(상점, 캐릭터정보 등)

        startScene.Logo(preLoad);

        player.DataLoad();


        stage.StartStage(player);
    }




}

