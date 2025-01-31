using TextRPG;
using System;

public class GameManager
{
    public static GameManager instance=new GameManager();

    private Action preLoad;

    private Player player = new Player();

    internal Player Player { get => player; private set => player = value; }

    private Shop shop = new Shop();

    internal Shop Shop { get => shop; private set => shop = value; }

    static void Main()
    {
        StartScene startScene = new StartScene();

        Stage stage = new Stage();

        instance.preLoad += instance.shop.SetSellItem;   // 미리 로드해둘 내용을 preLoad에 저장(상점, 캐릭터정보 등)
        instance.preLoad += instance.player.DataLoad;
        instance.preLoad += instance.player.LoadPlayerData;
        instance.preLoad += instance.player.LoadInvenData;

        startScene.Logo(instance.preLoad);

        stage.StartStage(instance.player, instance.shop);
    }


    public void ExitConsole()
    {
        Console.WriteLine("잘못된 입력입니다.");
        Environment.Exit(0);
    }

    public int InputReadLine()
    {
        try
        { 
            string line = Console.ReadLine();

            int input = int.Parse(line);

            return input;
        }
        catch(Exception e)
        {
            return -1;
        }
    }


}

