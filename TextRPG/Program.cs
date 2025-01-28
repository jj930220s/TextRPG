using TextRPG;
using System.Threading.Tasks;
using System;

class Program
{

    static void Main()
    {
        StartScene startScene = new StartScene();

        Player player= new Player();

        Stage stage = new Stage();
        
        startScene.Logo();

        player.DataLoad();


        stage.StartStage(player);
    }




}

