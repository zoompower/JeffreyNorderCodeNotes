using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_oefening
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmSysteem GebouwT = new AlarmSysteem();
            AlarmTakenCollectie Alarmen = new AlarmTakenCollectie();
            GebouwT.AlarmTaken += Alarmen.Sprinker;
            GebouwT.AlarmTaken += Alarmen.AlarmCentraleInlichten;
            GebouwT.AlarmTaken += Alarmen.HokkenOpenZetten;
            GebouwT.AlarmSlaan("T2.33");
        }
    }

    public delegate void AlarmTaak(string locatie);

    class AlarmSysteem
    {
        public event AlarmTaak AlarmTaken;

        public void AlarmSlaan(string locatie)
        {
            if (AlarmTaken != null) AlarmTaken(locatie);
        }
    }

    class AlarmTakenCollectie
    {
        public void Sprinker(string locatie)
        {
            Console.WriteLine($"Sprinkling op locatie: {locatie}");
        }
        public void AlarmCentraleInlichten(string locatie)
        {
            Console.WriteLine($"Beste alarmcentrale, het gaat niet goed op locatie: {locatie}");
        }
        public void HokkenOpenZetten(string locatie)
        {
            Console.WriteLine($"Alle hokken zijn geopent op locatie: {locatie}");
        }
    }
}
