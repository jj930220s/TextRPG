using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextRPG
{
    internal class StartScene
    {
        public void Logo(Action action)
        {
            ShowLogo();
            action?.Invoke();   //로고 보여줄 때 로드 미리 해두기
        }

        public void ShowLogo()
        {
            ShowSparta();
            Console.WriteLine("\n계속하려면 아무 키나 누르세요");
            Console.ReadKey();
            Console.Clear();
        }


        private void ShowSparta()
        {
            
            Console.WindowHeight = 60;
            Console.WindowWidth = 200;
            Console.WriteLine("                                                                                                                                                    ");
            Console.WriteLine("                                                                                                                                                    ");
            Console.WriteLine("                                          -::-.                                                                                                     ");
            Console.WriteLine("                                        :$$@$$$;.                                                                                                   ");
            Console.WriteLine("                                       $$##$$$$$=,                                                                                                  ");
            Console.WriteLine("                                      !@@!=$$#@$@#.                                                                                                 ");
            Console.WriteLine("                                      @#::-!:-###@*                                                                                                 ");
            Console.WriteLine("      :,                             ;#,  ....-:@#@                                                                                                 ");
            Console.WriteLine("      .                              ,@, .,,,~*=#@#                          _________ ___  ___  ___  ________           ___  ________              ");
            Console.WriteLine(@"       #-                            =:.,...,-::$@@-                       |\___   ___\\  \|\  \|\  \|\   ____\         |\  \|\   ____\            ");
            Console.WriteLine(@"       ~@-                           =**@=,;#@~::$@~                       \|___ \  \_\ \  \\\  \ \  \ \  \___|_        \ \  \ \  \___|_           ");
            Console.WriteLine(@"        @@~                          !;#@@-*@$$#:!#,                            \ \  \ \ \   __  \ \  \ \_____  \        \ \  \ \_____  \          ");
            Console.WriteLine(@"        -@@:                         !,-*;.,:!*:~*#*                             \ \  \ \ \  \ \  \ \  \|____|\  \        \ \  \|____|\  \         ");
            Console.WriteLine(@"         $@@!                        -. .- .;..-~=$:                              \ \__\ \ \__\ \__\ \__\____\_\  \        \ \__\____\_\  \        ");
            Console.WriteLine(@"         .@@@*                       .,.,..-~!~-:**-                               \|__|  \|__|\|__|\|__|\_________\        \|__|\_________\       ");
            Console.WriteLine(@"          ,@@@$.                     .-,=$#@@#*:;*!                                                     \|_________|            \|_________|       ");
            Console.WriteLine(@"           :@@@@!                    .-,@=*=@@#;;==                                                                                                ");
            Console.WriteLine(@"            =@@@@,                    *-@=-,=@@**@,                                                                                                ");
            Console.WriteLine(@"             #@@@!                    :=@@@@@@@@@@;$!.                      ________  ________  ________  ________  _________  ________  ___       ");
            Console.WriteLine(@"              #@@@-                   .@@@#$=*=@@#-:@#=~.                  |\   ____\|\   __  \|\   __  \|\   __  \|\___   ___\\   __  \|\  \      ");
            Console.WriteLine(@"              .#@@#                    $@~,;~,*@@=-. :@@@:                 \ \  \___|\ \  \|\  \ \  \|\  \ \  \|\  \|___ \  \_\ \  \|\  \ \  \     ");
            Console.WriteLine(@"               ,@@@=                   *@;~-:**@@$,.   !*~,                 \ \_____  \ \   ____\ \   __  \ \   _ _\    \ \  \ \ \   __  \ \  \    ");
            Console.WriteLine(@"                -@@@:                  !@$=#$!$@@*-..,:~----,                \|____|\  \ \  \___|\ \  \ \  \ \  \\  \|   \ \  \ \ \  \ \  \ \__\   ");
            Console.WriteLine(@"                 -=@@-                 ~@@#@@@@@@$!!!;~~---,,,                 ____\_\  \ \__\    \ \__\ \__\ \__\\ _\    \ \__\ \ \__\ \__\|__|   ");
            Console.WriteLine(@"                   ~##.                ;@@@@@@@@@@@$!:~~---,,,,               |\_________\|__|     \|__|\|__|\|__|\|__|    \|__|  \|__|\|__|   ___ ");
            Console.WriteLine(@"                    .##               ,:#@@@@@@@@@$!:~:~:==;--,,              \|_________|                                                    |\__\");
            Console.WriteLine(@"                     ,@$             .~!~@@@@@@@@#*~----~=:~-~=!-.                                                                            \|__|");
            Console.WriteLine("                      ,@=         ..---;=@@@@@@@#=:~-,,--~~:::*=*-,                                                                                 ");
            Console.WriteLine("                       :@:!     ...-;#=;$#==#@@@#=*!!!==$$$=$=!!;~--                                                                                ");
            Console.WriteLine("                      .!$~ . :!;;*=#@=!.-;!=$$#######@######@@@@$*!:-                                                                               ");
            Console.WriteLine("                      ,*:**~~=@@@@@@#==.,-,!$$$$$=*!:;;;:~~~~-~:!$@#!:-                                                                             ");
            Console.WriteLine("                         #@@@@@@@#!,.  ..-,-;*$**!!!;::~--~---------@$!:                                                                            ");
            Console.WriteLine("                        --#@@          .,,,::-:=$!;;::~~----------,---#=!,                                                                          ");
            Console.WriteLine("                         ~ *@-         .-,,;*-~;;*$#*!!*!;;;;!!;~:-----~$$-                                                                         ");
            Console.WriteLine("                          ..           ,-,-:!--~:!#==$#@@@@@@@@@##=*;:~--~$                                                                         ");
            Console.WriteLine("                                       -,,-;:---;;=;;;;#@@@@@@@@@@@@@#$*;~-                                                                         ");
            Console.WriteLine("                                       --,-~~,-~:~~*~;;!@@@@@#==**$#@@@@@=:                                                                         ");
            Console.WriteLine("                                       :!--;;---~--::;!*@@@@@@!!*;::;=#@@@#                                                                         ");
            Console.WriteLine("                                     ...*--~~:-~~-~;;=$#@@@@@@#===!::-~~:!=                                                                         ");
            Console.WriteLine("                                 ...    *;~~~::~~-~;=#@@@@@@@@@@#$$*==!-,,,                                                                         ");
            Console.WriteLine("                              ~:,        =;!;;;:~:;*@@@@@@@@@@@@@@#=!;!!~,,                                                                         ");


        }
    }
}


                                              
