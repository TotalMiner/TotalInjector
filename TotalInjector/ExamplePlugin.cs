using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using StudioForge.TotalMiner.API;
using StudioForge.TotalMiner;
using Harmony;
using System.Reflection;
using TotalInjector.Patch;
using System.IO;

namespace TotalInjector
{
    public class ExamplePlugin : ITMPlugin
    {
        private ITMGame _game;

        public void Draw(ITMPlayer player, ITMPlayer virtualPlayer)
        {
            
        }

        public bool HandleInput(ITMPlayer player)
        {
            return false;
        }

        public void Initialize(ITMPluginManager mgr, string path)
        {
            var harmony = HarmonyInstance.Create("ga.totalminer.totalinjector");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void InitializeGame(ITMGame game)
        {
            Logger.Logged += Logged;
            _game = game;
        }

        private void Logged(LogType type, string msg)
        {
            File.AppendAllText("test.log", $"{msg}\n");
            _game.AddNotification(msg, NotifyRecipient.Global);
        }

        public void PlayerJoined(ITMPlayer player)
        {
            
        }

        public void PlayerLeft(ITMPlayer player)
        {
            
        }

        public void Update()
        {
            
        }

        public void Update(ITMPlayer player)
        {
            
        }

        public void WorldSaved(int version)
        {
            
        }
    }
}
