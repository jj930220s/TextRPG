using TextRPG;
using System;

public class GameManager
{
    public static GameManager instance=new GameManager();

    private Action preLoad;

    private Player player = new Player();

    internal Player Player { get => player; set => player = value; }


    static void Main()
    {
        StartScene startScene = new StartScene();

        Stage stage = new Stage();

        Shop shop = new Shop();

        instance.preLoad += shop.SetSellItem;   // 미리 로드해둘 내용을 preLoad에 저장(상점, 캐릭터정보 등)
        instance.preLoad += instance.player.DataLoad;
        instance.preLoad += instance.player.LoadPlayerData;
        instance.preLoad += instance.player.LoadInvenData;

        startScene.Logo(instance.preLoad);

        stage.StartStage(instance.player);
    }


    public void ExitConsole()
    {
        Console.WriteLine("범위에서 벗어났습니다.");
        Environment.Exit(0);
    }



}

