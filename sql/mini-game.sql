CREATE TABLE "Map" (
  "Id" SERIAL PRIMARY KEY,
  "Name" varchar,
  "BackgroundImage" varchar
);

CREATE TABLE "Monster" (
  "Id" SERIAL PRIMARY KEY,
  "Name" varchar,
  "Health" int,
  "Sprite" varchar,
  "Width" varchar,
  "Height" varchar,
  "RespawnTime" int
);

CREATE TABLE "MapMonster" (
  "Id" SERIAL PRIMARY KEY,
  "MapId" int,
  "MonsterId" int,
  "PositionX" int,
  "PositionY" int,
  "Facing" varchar,
  "CurrentHealth" int
);

ALTER TABLE "MapMonster" ADD FOREIGN KEY ("MonsterId") REFERENCES "Monster" ("Id") ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE "MapMonster" ADD FOREIGN KEY ("MapId") REFERENCES "Map" ("Id") ON DELETE CASCADE ON UPDATE CASCADE;
