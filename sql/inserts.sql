insert into Klasses (name, description, department) values ("CHEM-101", "Intro to Chemistry", "Science");
insert into Klasses (name, description, department) values ("CHEM-102", "Organic Chemistry", "Science");
insert into Klasses (name, description, department) values ("MAT-101", "Algebra", "Science");
insert into Klasses (name, description, department) values ("MAT-102", "Calculus", "Science");
insert into Klasses (name, description, department) values ("MAT-103", "Linear Algebra", "Science");

insert into Students (name, email) values ("Bob", "bob@aol.com");
insert into Students (name, email) values ("Alice", "alice@aol.com");
insert into Students (name, email) values ("Sara", "sara@aol.com");
insert into Students (name, email) values ("James", "james@aol.com");
insert into Students (name, email) values ("Danny", "danny@aol.com");

insert into KlassStudent (KlassesName, StudentsId) values ("CHEM-101", 1);
insert into KlassStudent (KlassesName, StudentsId) values ("CHEM-101", 2);
insert into KlassStudent (KlassesName, StudentsId) values ("CHEM-101", 3);
insert into KlassStudent (KlassesName, StudentsId) values ("MAT-102", 2);
insert into KlassStudent (KlassesName, StudentsId) values ("MAT-102", 4);
