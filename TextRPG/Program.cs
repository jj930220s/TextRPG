using TextRPG;
using System.Threading.Tasks;
using System;

class Program
{
    static void Main(string[] args)
    {
        StartScene startScene = new StartScene();

        Player player= new Player();

        startScene.Logo();
        player.MakePlayer();


    }




}

