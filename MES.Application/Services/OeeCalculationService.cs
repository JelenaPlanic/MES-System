namespace MES.Application.Services;

public static class OeeCalculationService
{
    public static double CalculateAvailability(double plannedMinutes, double downtimeMinutes)
    {
        if (plannedMinutes <= 0) return 0;

        var runTime = plannedMinutes - downtimeMinutes;
        return Math.Max(0, runTime / plannedMinutes);
    }

    public static double CalculatePerformance(int producedQuantity, double cycleTimeSeconds, double runTimeMinutes)
    {
        if (runTimeMinutes <= 0) return 0;

        var idealTimeMinutes = (producedQuantity * cycleTimeSeconds) / 60.0;
        return Math.Min(1, idealTimeMinutes / runTimeMinutes);
    }

    public static double CalculateQuality(int producedQuantity, int defectQuantity)
    {
        if (producedQuantity <= 0) return 0;

        var goodQuantity = producedQuantity - defectQuantity;
        return Math.Max(0, (double)goodQuantity / producedQuantity);
    }

    public static double CalculateOee(double availability, double performance, double quality)
    {
        return availability * performance * quality;
    }
}
