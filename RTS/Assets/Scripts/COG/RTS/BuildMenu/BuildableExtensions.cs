using System;

namespace COG.RTS.BuildMenu
{
    public static class BuildableExtensions
    {
        public static BuildableCategory Category(this Buildable buildable)
        {
            switch (buildable)
            {
                case Buildable.Rifleman:
                case Buildable.RocketMan:
                case Buildable.JetpackMan:
                case Buildable.Engineer:
                case Buildable.Grenadier:
                case Buildable.Tesla:
                    return BuildableCategory.Infantry;
                case Buildable.Scout:
                case Buildable.RocketTruck:
                case Buildable.Tank:
                case Buildable.Transport:
                case Buildable.Apc:
                case Buildable.Miner:
                    return BuildableCategory.Vehicle;
                case Buildable.CommandCentre:
                case Buildable.OreProcessor:
                case Buildable.Barracks:
                case Buildable.LightVehicleFactory:
                case Buildable.ScienceLab:
                case Buildable.HeavyVehicleFactory:
                case Buildable.OreStorage:
                    return BuildableCategory.ProductionBuilding;
                case Buildable.MiniGunTurret:
                case Buildable.RocketTurret:
                case Buildable.ShockTurret:
                case Buildable.ShieldGenerator:
                    return BuildableCategory.DefensiveBuilding;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buildable), buildable, null);
            }
        }
    }
}