using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace Breakout
{
    static class Sound
    {
        public static SoundPlayer spWin = new SoundPlayer(Properties.Resources.BeepWin);
        public static SoundPlayer spFail = new SoundPlayer(Properties.Resources.BeepFail);
        public static SoundPlayer spMove = new SoundPlayer(Properties.Resources.BeepMove);
        public static SoundPlayer spPick = new SoundPlayer(Properties.Resources.BeepPoint);
    }
}