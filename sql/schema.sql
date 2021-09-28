CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Klasses" (
    "Name" TEXT NOT NULL CONSTRAINT "PK_Klasses" PRIMARY KEY,
    "Description" TEXT NOT NULL,
    "Department" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Students" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Students" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Email" varchar(35) NULL
);
CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE IF NOT EXISTS "Teachers" (
    "TeacherId" INTEGER NOT NULL CONSTRAINT "PK_Teachers" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL
);
CREATE TABLE IF NOT EXISTS "Books" (
    "BId" INTEGER NOT NULL CONSTRAINT "PK_Books" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NULL,
    "ISBN" TEXT NULL,
    "SerialNumber" TEXT NULL,
    "OwnerId" INTEGER NULL,
    CONSTRAINT "FK_Books_Students_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Students" ("Id") ON DELETE RESTRICT
);
CREATE TABLE IF NOT EXISTS "KlassStudent" (
    "KlassesName" TEXT NOT NULL,
    "StudentsId" INTEGER NOT NULL,
    CONSTRAINT "PK_KlassStudent" PRIMARY KEY ("KlassesName", "StudentsId"),
    CONSTRAINT "FK_KlassStudent_Klasses_KlassesName" FOREIGN KEY ("KlassesName") REFERENCES "Klasses" ("Name") ON DELETE CASCADE,
    CONSTRAINT "FK_KlassStudent_Students_StudentsId" FOREIGN KEY ("StudentsId") REFERENCES "Students" ("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "KlassTeacher" (
    "KlassesName" TEXT NOT NULL,
    "TeachersTeacherId" INTEGER NOT NULL,
    CONSTRAINT "PK_KlassTeacher" PRIMARY KEY ("KlassesName", "TeachersTeacherId"),
    CONSTRAINT "FK_KlassTeacher_Klasses_KlassesName" FOREIGN KEY ("KlassesName") REFERENCES "Klasses" ("Name") ON DELETE CASCADE,
    CONSTRAINT "FK_KlassTeacher_Teachers_TeachersTeacherId" FOREIGN KEY ("TeachersTeacherId") REFERENCES "Teachers" ("TeacherId") ON DELETE CASCADE
);
CREATE INDEX "IX_Books_OwnerId" ON "Books" ("OwnerId");
CREATE INDEX "IX_KlassStudent_StudentsId" ON "KlassStudent" ("StudentsId");
CREATE INDEX "IX_KlassTeacher_TeachersTeacherId" ON "KlassTeacher" ("TeachersTeacherId");
