using System;

namespace CSharpLearning
{
    public class TrackItemExample : IDemonstrate
    {

        public static void Output(TrackItem t)
        {
            string p1 = t.ToString();
            string p2 = Convert.ToString((int)t, 2).PadLeft(5, '0');
            Console.WriteLine($"{p2,-4} -- {p1}");
        }
        public void Demonstrate()
        {
            TrackItem t1 = TrackItem.Track1 | TrackItem.Track2;
            Output(t1);
            TrackItem t2 = TrackItem.Track3 | TrackItem.Track4 | TrackItem.Track5;
            Output(t2);
            TrackItem t3 = TrackItem.Track1 | TrackItem.Track2 | TrackItem.Track3 | TrackItem.Track4 | TrackItem.Track5;
            Output(t3);
            Output(TrackItem.AllTracks);
        }
    }
}
