const int FinancialYearStartMonth = 7;

DoWork();
return;


static void DoWork()
{
    Console.Write("Start date: ");

    if (!DateOnly.TryParse(Console.ReadLine(), out var startDate))
    {
        Console.WriteLine("Please enter a valid date.");
        return;
    }

    foreach (var financialYear in GenerateYears(startDate).Take(5))
    {
        Print(financialYear);
    }
}

static IEnumerable<FinancialYear> GenerateYears(DateOnly startDate)
{
    var periods = new List<FinancialPeriod>();

    foreach (var period in GeneratePeriods(startDate))
    {
        periods.Add(period);

        if (period.PeriodNumber != 12) continue;

        // calculate days in the financial year - assuming days in the full year rather than a partial year from the startDate / month
        var financialYearStartDate = new DateOnly(period.StartDate.Year - 1, FinancialYearStartMonth, 1);
        var financialYearEndDate = financialYearStartDate.AddYears(1);
        var days = financialYearEndDate.DayNumber - financialYearStartDate.DayNumber;
        var label = $"{financialYearStartDate.Year}-{financialYearEndDate.Year}";

        yield return new FinancialYear(label, days, [.. periods]);

        periods.Clear();
    }
}

static IEnumerable<FinancialPeriod> GeneratePeriods(DateOnly startDate)
{
    var periodStartDate = new DateOnly(startDate.Year, startDate.Month, 1);
    var periodNumber = (periodStartDate.Month + 12 - FinancialYearStartMonth) % 12 + 1;

    while (true)
    {
        var periodEndDate = periodStartDate.AddMonths(1).AddDays(-1);

        yield return new FinancialPeriod(periodStartDate, periodEndDate, periodNumber);

        periodStartDate = periodStartDate.AddMonths(1);
        periodNumber = periodNumber % 12 + 1;
    }

    // ReSharper disable once IteratorNeverReturns - this is intended to continue forever - until the consuming iterator stops it
}

static void Print(FinancialYear financialYear)
{
    Console.WriteLine($"Financial Year {financialYear.Label}:");
    Console.WriteLine($"Days: {financialYear.Days}");
    Console.WriteLine("Periods:");
    Console.WriteLine();
    Console.WriteLine("Start        End          Period Number");

    foreach (var period in financialYear.Periods)
    {
        Console.WriteLine($"{period.StartDate:yyyy-MM-dd}   {period.EndDate:yyyy-MM-dd}   {period.PeriodNumber}");
    }

    Console.WriteLine();
}


internal record FinancialPeriod(DateOnly StartDate, DateOnly EndDate, int PeriodNumber);

internal record FinancialYear(string Label, int Days, FinancialPeriod[] Periods);
