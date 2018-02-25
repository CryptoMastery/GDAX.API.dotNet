using System;

namespace CryptoMastery.GDAX.API.Model
{
    public enum LimitOrderTimeInForceFlags
    {
        GTC,
        GTT,
        IOC,
        FOK
    }

    public static class LimitOrderTimeInForceFlagsMethods
    {
        public static string GetString(this LimitOrderTimeInForceFlags flag)
        {
            switch (flag)
            {
                case LimitOrderTimeInForceFlags.GTC:
                    return "GTC";
                case LimitOrderTimeInForceFlags.GTT:
                    return "GTT";
                case LimitOrderTimeInForceFlags.IOC:
                    return "IOC";
                case LimitOrderTimeInForceFlags.FOK:
                    return "FOK";
                default:
                    throw new ArgumentException($"Unsupported LimitOrderTimeInForceFlag");
            }
        }

        public static LimitOrderTimeInForceFlags FromString(this LimitOrderTimeInForceFlags flag, string flagText)
        {
            switch (flagText)
            {
                case "GTC":
                    return LimitOrderTimeInForceFlags.GTC;
                case "GTT":
                    return LimitOrderTimeInForceFlags.GTT;
                case "IOC":
                    return LimitOrderTimeInForceFlags.IOC;
                case "FOK":
                    return LimitOrderTimeInForceFlags.FOK;
                default:
                    throw new ArgumentException($"Unsupported LimitOrderTimeInForceFlag {flagText}");
            }
        }
    }
}