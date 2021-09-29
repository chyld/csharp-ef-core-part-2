CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Klasses" (
    "Name" TEXT NOT NULL CONSTRAINT "PK_Klasses" PRIMARY KEY,
    "Description" TEXT NULL,
    "Department" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Students" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Students" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Email" varchar(35) NOT NULL
);
CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE IF NOT EXISTS "Teachers" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Teachers" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Books" (
    "SerialNumber" TEXT NOT NULL CONSTRAINT "PK_Books" PRIMARY KEY,
    "Title" TEXT NULL,
    "ISBN" TEXT NULL,
    "OwnerId" INTEGER NULL,
    CONSTRAINT "FK_Books_Students_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Students" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "Registrations" (
    "KlassName" TEXT NOT NULL,
    "StudentId" INTEGER NOT NULL,
    "Grade" REAL NOT NULL,
    CONSTRAINT "PK_Registrations" PRIMARY KEY ("KlassName", "StudentId"),
    CONSTRAINT "FK_Registrations_Klasses_KlassName" FOREIGN KEY ("KlassName") REFERENCES "Klasses" ("Name") ON DELETE CASCADE,
    CONSTRAINT "FK_Registrations_Students_StudentId" FOREIGN KEY ("StudentId") REFERENCES "Students" ("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "KlassTeacher" (
    "KlassesName" TEXT NOT NULL,
    "TeachersId" INTEGER NOT NULL,
    CONSTRAINT "PK_KlassTeacher" PRIMARY KEY ("KlassesName", "TeachersId"),
    CONSTRAINT "FK_KlassTeacher_Klasses_KlassesName" FOREIGN KEY ("KlassesName") REFERENCES "Klasses" ("Name") ON DELETE CASCADE,
    CONSTRAINT "FK_KlassTeacher_Teachers_TeachersId" FOREIGN KEY ("TeachersId") REFERENCES "Teachers" ("Id") ON DELETE CASCADE
);
CREATE INDEX "IX_Books_OwnerId" ON "Books" ("OwnerId");
CREATE INDEX "IX_KlassTeacher_TeachersId" ON "KlassTeacher" ("TeachersId");
CREATE INDEX "IX_Registrations_StudentId" ON "Registrations" ("StudentId");
