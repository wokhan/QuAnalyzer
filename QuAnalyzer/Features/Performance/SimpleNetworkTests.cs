
using System.Net.NetworkInformation;

namespace QuAnalyzer.Features.Performance
{
    public static class SimpleNetworkTests
    {
        public static long GetMTU(string host)
        {
            var startsize = 2000;
            var smaller = 0;
            var higher = 4000;

            var keepgoing = true;
            using (var pong = new Ping())
            {
                while (keepgoing)
                {
                    PingReply ret = pong.Send(host, 5000, new byte[startsize], new PingOptions() { DontFragment = true });
                    if (ret.Status == IPStatus.PacketTooBig)
                    {
                        higher = startsize;
                        startsize = higher - (higher - smaller) / 2;
                    }

                    if (ret.Status == IPStatus.Success)
                    {
                        smaller = startsize;
                        startsize = smaller + (higher - smaller) / 2;
                    }


                    if (smaller == higher - 1)
                    {
                        keepgoing = false;
                        startsize = smaller;
                    }
                }
            }
            return startsize;
        }

        public static long Ping(string host)
        {
            using (var pong = new Ping())
            {
                return pong.Send(host).RoundtripTime;
            }
        }


        public static double MeasureBandwidth(string host)
        {
            var optsize = GetMTU(host);

            using (var pong = new Ping())
            {
                PingReply ret = pong.Send(host, 5000, new byte[optsize * 10], new PingOptions() { DontFragment = false });

                if (ret.Status == IPStatus.Success)
                {
                    return optsize / ret.RoundtripTime / 10 * 1000;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
