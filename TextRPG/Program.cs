using TextRPG;
using System.Threading.Tasks;
using System;

class Program
{
    public static Action playerStatus;

    static void Main(string[] args)
    {
        StartScene startScene = new StartScene();

        Player player= new Player();

        Stage stage = new Stage();
        
        startScene.Logo();

        player.MakePlayer();

        playerStatus += player.ShowCharStatus;

        stage.StartStage(playerStatus,playerStatus);
    }




}

