using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace GaryBot.Commands
{
    internal class BotCommands : BaseCommandModule
    {
        [Command("Hejka")]
        public async Task MyFirstCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hej {ctx.User.Username} :]");
        }

        private readonly Random _random = new Random();

        private readonly List<string> _champions = new List<string>
        {
            "Aatrox", "Ahri", "Akali", "Akshan", "Alistar", "Amumu", "Anivia", "Annie", "Aphelios", "Ashe", "Aurelion Sol", "Azir", "Bard", "Bel'Veth", "Blitzcrank", "Brand", "Braum", 
            "Briar", "Caitlyn", "Camille", "Cassiopeia", "Cho'Gath", "Corki", "Darius", "Diana", "Dr. Mundo", "Draven", "Ekko", "Elise", "Evelynn", "Ezreal", "Fiddlesticks", "Fiora", 
            "Fizz", "Galio", "Gangplank", "Garen", "Gnar", "Gragas", "Graves", "Gwen", "Hecarim", "Heimerdinger", "Hwei", "Illaoi", "Irelia", "Ivern", "Janna", "Jarvan IV", "Jax", "Jayce", 
            "Jhin", "Jinx", "K'Sante", "Kai'Sa", "Kalista", "Karma", "Karthus", "Kassadin", "Katarina", "Kayle", "Kayn", "Kennen", "Kha'Zix", "Kindred", "Kled", "Kog'Maw", "LeBlanc", 
            "Lee Sin", "Leona", "Lillia", "Lissandra", "Lucian", "Lulu", "Lux", "Malphite", "Malzahar", "Maokai", "Master Yi", "Milio", "Miss Fortune", "Mordekaiser", "Morgana", "Naafiri", 
            "Nami", "Nasus", "Nautilus", "Neeko", "Nidalee", "Nilah", "Nocturne", "Nunu & Willump", "Olaf", "Orianna", "Ornn", "Pantheon", "Poppy", "Pyke", "Qiyana", "Quinn", "Rakan", "Rammus", 
            "Rek'Sai", "Rell", "Renata Glasc", "Renekton", "Rengar", "Riven", "Rumble", "Ryze", "Samira", "Sejuani", "Senna", "Seraphine", "Sett", "Shaco", "Shen", "Shyvana", "Singed", "Sion", 
            "Sivir", "Skarner","Smolder", "Sona", "Soraka", "Swain", "Sylas", "Syndra", "Tahm Kench", "Taliyah", "Talon", "Taric", "Teemo", "Thresh", "Tristana", "Trundle", "Tryndamere", "Twisted Fate", 
            "Twitch", "Udyr", "Urgot", "Varus", "Vayne", "Veigar", "Vel'Koz", "Vex", "Vi", "Viego", "Viktor", "Vladimir", "Volibear", "Warwick", "Wukong", "Xayah", "Xerath", "Xin Zhao", "Yasuo", 
            "Yone", "Yorick", "Yuumi", "Zac", "Zed", "Zeri", "Ziggs", "Zilean", "Zoe", "Zyra"
        };


        [Command("Arena")]
        public async Task RandomChampions(CommandContext ctx, int ile)
        {
            var team = new List<string>();

            for (int j = 0; j < ile; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    int randomIndex = _random.Next(_champions.Count);
                    string randomChampion = _champions[randomIndex];
                    team.Add(randomChampion);
                    _champions.RemoveAt(randomIndex);
                }
                await ctx.Channel.SendMessageAsync($"Drużyna {j+1}: {string.Join(", ", team)}");
                team.Clear();
            }
        }

        [Command("Los")]
        public async Task RandomChampion(CommandContext ctx)
        {
            int randomIndex = _random.Next(_champions.Count);
            string randomChampion = _champions[randomIndex];

            await ctx.Channel.SendMessageAsync($"Losowy champion: {randomChampion}");
        }
    }

}
