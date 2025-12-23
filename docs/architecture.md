**rOpenBid monorepo structure**

---

## **OpenBid – Full Directory Structure**

```
OpenBid/                          # Git repo root
│
├── backend/
│   │
│   ├── AuctionsSolution.slnx
│   │
│   ├── services/
│   │   │
│   │   └── AuctionService.Api/
│   │       ├── Controllers/
│   │       │   └── AuctionsController.cs
│   │       │
│   │       ├── Data/
│   │       │   ├── AuctionDbContext.cs
│   │       │   ├── DbInitializer.cs
│   │       │   └── Migrations/
│   │       │
│   │       ├── Entities/
│   │       │   ├── Auction.cs
│   │       │   ├── Item.cs
│   │       │   └── Status.cs
│   │       │
│   │       ├── DTOs/
│   │       │   ├── AuctionDto.cs
│   │       │   ├── CreateAuctionDto.cs
│   │       │   └── UpdateAuctionDto.cs
│   │       │
│   │       ├── Mapping/
│   │       │   └── AuctionProfile.cs
│   │       │
│   │       ├── Services/
│   │       │   └── AuctionService.cs   # optional business logic
│   │       │
│   │       ├── Program.cs
│   │       ├── appsettings.json
│   │       └── AuctionService.Api.csproj
│   │
│   ├── docker-compose.yml
│   └── docker-compose.override.yml     # optional
│
├── tests/
│   │
│   └── AuctionService.Tests/
│       ├── Unit/
│       │   ├── AuctionMappingTests.cs
│       │   └── AuctionValidationTests.cs
│       │
│       ├── Integration/
│       │   ├── AuctionsControllerTests.cs
│       │   └── DatabaseMigrationTests.cs
│       │
│       └── AuctionService.Tests.csproj
│
├── frontend/
│   │
│   └── openbid-ui/
│       ├── src/
│       ├── public/
│       └── package.json
│
├── infra/
│   │
│   ├── docker/
│   │   └── postgres/
│   │
│   ├── k8s/
│   │   ├── auctionservice.yaml
│   │   └── postgres.yaml
│   │
│   └── terraform/
│       └── main.tf
│
├── docs/
│   ├── architecture.md
│   ├── decisions.md
│   └── local-setup.md
│
├── .gitignore
└── README.md
```

---

## 🧠 Why this structure is **right**

### ✔ Clear boundaries

- `backend` → all .NET code
- `tests` → all tests (no mixing)
- `frontend` → React
- `infra` → Docker/K8s/Terraform
- `docs` → explanations
