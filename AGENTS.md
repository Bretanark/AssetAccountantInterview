# Codex Project Instructions

This is a deliberately minimal C# console exercise. Read `README.md` and `accounting-periods.md` before changing code.

## Working With Brent

- Be proactive and practical: make focused changes, verify them, and summarize the result.
- Do not stage files automatically. Brent stages reviewed files manually.
- Keep changes scoped to the requested behaviour.
- Do not initialise Git, add/stage files, or commit unless Brent explicitly asks.

## Design Intent

- Keep the solution centred on `Program.cs`; do not introduce layers or abstractions that do not earn their keep.
- Retain lazy, potentially infinite period generation.
- Generate financial years by iterating periods rather than grouping an infinite sequence.
- A start date in the middle of a financial year should yield the remaining periods through June as a partial first result.

## C# Conventions

- ReSharper green is the coding standard: no compiler warnings and no orange ReSharper marks where practical.
- Prefer arrays over lists for public API return types unless mutability is useful.
- Prefer `""` over `string.Empty`.
- Do not require an `Async` suffix.
- Do not use braces for a single-line `if` or `else` branch unless the other branch is multi-line.
- Prefer expression-bodied members for simple overrides and mappers.
- Keep intentionally empty constructors and other empty blocks on one line.
- Assign awaited or complex results to local variables before using or returning them, so debugging stays easy.
- Keep lines comfortably below 200 characters.
- Keep validation proportionate to the console exercise; do not over-engineer input handling.
