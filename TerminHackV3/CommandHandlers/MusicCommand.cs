using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace TerminHackV3.CommandHandlers
{
    public class MusicCommand : ICommandHandler
    {
        public bool AppliesTo(string command)
        {
            command.ToLower();
            return command == "music";
        }


        public void Handle(string[] arguments, MainTerminal terminal)
        {
            List<string> validMusicNames = new List<string> { "Silence", "Mr.C.Soldier - Silence.wav", "Silent Hack", "Silent Tool" };
            string[] musicName = { "silenthack", "silent", "silenttool" };
            Random rnd = new Random();
            int index = 0;
            string[] music = {
                Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\Audio\\Music", "Mr. C. Soldier - Silence.wav"),
                Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\Audio\\Music", "Mr. C. Soldier - Silent Hack.wav"),
                Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\Audio\\Music", "Mr. C. Soldier - Silent Tool.wav")
            };
            if (arguments[0] == "play")
            {
                if (Array.Exists(musicName, element => element == arguments[1].ToLower()))
                {
                    index = arguments[1] switch
                    {
                        "silence" => index = 0,
                        "silenthack" => index = 1,
                        "silenttool" => index = 2
                    };
                    SoundPlayer currMusic = new SoundPlayer(music[index]);
                    currMusic.Play();
                }
                else {
                    index = rnd.Next();
                    SoundPlayer currMusic = new SoundPlayer(music[index]);
                    currMusic.Play();
                }
            }
            else if (arguments[0] == "stop")
            {   
                SoundPlayer currMusic = new SoundPlayer(music[index]);
                if (arguments[1] == "all") currMusic.Dispose();
            }

            else if (arguments[0] == "next")
            {
                index++;
                if (index == 3) index = 2;
                SoundPlayer currMusic = new SoundPlayer(music[index]);
                currMusic.Play();
            }

            else if (arguments[0] == "previous" || arguments[0] == "prev") {
                SoundPlayer currMusic = new SoundPlayer(music[index]);
                index--;
                if (index == -1) index = 2;
                else currMusic.Play();
            }
        }
    }
}
