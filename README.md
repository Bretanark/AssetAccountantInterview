# Asset Accountant Interview Exercise

A small C# console application for generating calendar-month accounting periods and grouping them into July-to-June financial years.

The exercise brief is in [accounting-periods.md](accounting-periods.md).

## Run

```powershell
dotnet run
```

Enter a date when prompted. The application normalises it to the first day of its calendar month, then prints several financial years.

## Behaviour

- Financial years start on 1 July and end on 30 June.
- Period numbers run from 1 in July through 12 in June.
- Period generation is lazy and potentially infinite.
- Starting during a financial year produces a partial first result through June; its day count still describes the complete financial year.

## Scope

This is intentionally a small algorithm exercise. Keep the application centred on `Program.cs` unless a real need emerges; avoid adding architecture, frameworks, or test infrastructure for their own sake.
