# MES sistem — Informacioni sistem za podršku izvršavanju proizvodnje

Projektni zadatak iz predmeta **AUPS** (Analiza i upravljanje poslovnim sistemima), Fakultet tehničkih nauka, Univerzitet u Novom Sadu, školska 2025/2026.

Tema: *Sistemi za podršku izvršavanju proizvodnje — Primena u industriji (Manufacturing Execution Systems)*

## O projektu

Aplikacija podržava praćenje izvršavanja proizvodnje: radne naloge, zastoje mašina, defekte proizvoda, i automatski obračun **OEE** (Overall Equipment Effectiveness) — ključnog pokazatelja efikasnosti proizvodne opreme.

## Tehnologije

- **Backend:** ASP.NET Core (.NET 10), C#
- **ORM:** Entity Framework Core
- **Baza podataka:** SQL Server (LocalDB za razvoj)
- **Mapiranje:** AutoMapper
- **API dokumentacija:** Swagger / Swashbuckle
- **Arhitektura:** Clean Architecture (Domain / Application / Infrastructure / API)

## Arhitektura

```
MES.sln
├── MES.Domain          → Entiteti, enum-i (bez zavisnosti)
├── MES.Application     → Servisi, DTO-ovi, interfejsi, AutoMapper profili
├── MES.Infrastructure  → EF Core, DbContext, Repository/Unit of Work implementacije
└── MES.API             → Kontroleri, middleware, konfiguracija
```

Korišćeni pattern-i: **Repository** i **Unit of Work** (generički, preko `IGenericRepository<T>` i `IUnitOfWork`), **DTO** razdvajanje ulaznih/izlaznih podataka, **Fluent API** konfiguracija baze.

## Domenski model

Entiteti: `Product`, `Machine`, `WorkOrder`, `Downtime`, `DowntimeReason`, `Defect`, `DefectType`, `User`, `Shift`.

Ključne relacije: jedan `Product`/`Machine`/`User` ima više `WorkOrder`-a; jedan `WorkOrder` ima više `Downtime` i `Defect` zapisa; `DowntimeReason`/`DefectType` su šifarnici.


## Pokretanje projekta

1. Kloniraj repozitorijum
2. Podesi connection string u `MES.API/appsettings.json` (podrazumevano koristi LocalDB)
3. Pokreni migracije:
   ```
   dotnet ef database update --project MES.Infrastructure --startup-project MES.API
   ```
4. Pokreni aplikaciju (`Ctrl+F5` u Visual Studiju, ili `dotnet run --project MES.API`)
5. Swagger UI se automatski otvara na `/swagger`

## Autor

Jelena — master studije, Informacioni menadžment, FTN Novi Sad
