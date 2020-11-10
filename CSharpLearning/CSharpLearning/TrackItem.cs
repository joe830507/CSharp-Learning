using System;

namespace CSharpLearning
{
    [Flags]
    public enum TrackItem
    {
        Track1 = 1,
        Track2 = 2,
        Track3 = 4,
        Track4 = 8,
        Track5 = 16,
        AllTracks = Track1 | Track2 | Track3 | Track4 | Track5
    }
}
