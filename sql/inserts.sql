insert into Klasses (name, description, department) values ("CHEM-101", "Intro to Chemistry", "Science");
insert into Klasses (name, description, department) values ("CHEM-102", "Organic Chemistry", "Science");
insert into Klasses (name, description, department) values ("MAT-101", "Algebra", "Mathematics");
insert into Klasses (name, description, department) values ("MAT-102", "Calculus", "Mathematics");
insert into Klasses (name, description, department) values ("MAT-103", "Linear Algebra", "Mathematics");

insert into Students (name, email) values ("Bob", "bob@aol.com");
insert into Students (name, email) values ("Alice", "alice@aol.com");
insert into Students (name, email) values ("Sara", "sara@aol.com");
insert into Students (name, email) values ("James", "james@aol.com");
insert into Students (name, email) values ("Danny", "danny@aol.com");

insert into Registrations (KlassName, StudentId, Grade) values ("CHEM-101", 1, 99);
insert into Registrations (KlassName, StudentId, Grade) values ("CHEM-102", 1, 88);
insert into Registrations (KlassName, StudentId, Grade) values ("MAT-101", 1, 75);
insert into Registrations (KlassName, StudentId, Grade) values ("CHEM-101", 2, 95);
