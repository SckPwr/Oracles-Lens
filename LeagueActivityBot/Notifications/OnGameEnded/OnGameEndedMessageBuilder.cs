using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueActivityBot.Abstractions;
using LeagueActivityBot.Constants;
using LeagueActivityBot.Entities;
using LeagueActivityBot.Models;

namespace LeagueActivityBot.Notifications.OnGameEnded
{
    public class OnGameEndedMessageBuilder
    {
        private readonly IRiotClient _riotClient;
        private MatchInfo _matchInfo;
        private Summoner[] _summoners;

        public OnGameEndedMessageBuilder(IRiotClient riotClient)
        {
            _riotClient = riotClient;
        }

        public async Task<string> Build(OnGameEndedNotification notification)
        {
            _matchInfo = await _riotClient.GetMatchInfo(notification.GameId);
            if (_matchInfo == null) return string.Empty;
            _summoners = notification.Summoners;
            
            var sb = new StringBuilder($"Team {GetAction()}\n\n{GetStats()}");
            return sb.ToString();
        }

        private string GetStats()
        {
            var sb = new StringBuilder();

            var team1Damage = _matchInfo.Info.GetTeamDamage(100);
            var team2Damage = _matchInfo.Info.GetTeamDamage(200);

            foreach (var summoner in _summoners)
            {
                var stat = _matchInfo.Info.Participants.First(p => p.SummonerName == summoner.Name);
                sb.Append($"<b><i>{summoner.Name}</i></b> on {stat.ChampionName}.\n{stat.GetScore()}, {stat.GetDamage(stat.TeamId == 100? team1Damage : team2Damage)}.");
                
                if (_matchInfo.Info.QueueId != (int)QueueType.ARAM)
                {
                    sb.Append($" {stat.GetCreepScore()}, {stat.GetVisionScore()}.");
                }
                
                sb.Append("\n\n");
            }

            return sb.ToString();
        }
        
        private string GetAction()
        {
            var summonerName = _summoners.First().Name;
            var summonersStat = _matchInfo.Info.Participants.First(p => p.SummonerName == summonerName);

            if (summonersStat.Win) return "won!";
            if (summonersStat.GameEndedInEarlySurrender) return "FFed 15.";
            if (summonersStat.GameEndedInSurrender) return "FFed.";
                
            return "lost.";
        }
    }
}