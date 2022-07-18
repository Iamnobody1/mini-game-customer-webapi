CREATE TABLE "RefreshToken" (
  "Id" SERIAL PRIMARY KEY,
  "Token" varchar,
  "Expires" timestamp,
  "Created" timestamp,
  "CreatedByIp" varchar,
  "Revoked" timestamp,
  "RevokedByIp" varchar,
  "ReplacedByToken" varchar,
  "ReasonRevoked" varchar,
  "IsExpired" bool,
  "IsRevoked" bool,
  "IsActive" bool,
);