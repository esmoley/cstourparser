using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_s_tournament_parser
{
    public enum TournamentStatus
    {
        Live,Upcoming,Result
    }
    public class TournamentInfo
    {
        public string url = "";
        public string[] Team = new string[2];
        public string score = ""; //ex: 1 - 1
        public string date;
        public TournamentStatus status;
    }
}
