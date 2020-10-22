


            --/// Um SQL Abfragen zu machen: rechte Maus auf unsere Datenverbindung und "Neue Abfrage" auswählen.
            --/// Das offnet uns eine neue SQL Query.

-- SELECTS INTTRO UND INNER JOINs
SELECT * FROM Animal;
SELECT * FROM Zoo;

-- sehen welche Animals der Zoo mit ID 1 hat:
SELECT a.Name FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId 
WHERE za.ZooId = 1

--tests für ShowAssociatedAnimals
SELECT * FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId WHERE za.ZooId = @ZooId
SELECT * FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId WHERE za.ZooId = 3

--tests for remove Animal from Zoo
DELETE FROM ZooAnimal WHERE ZooId = @ZooId AND AnimalId = @AnimalId;

DELETE FROM ZooAnimal WHERE ZooId = 2 AND AnimalId = 6; --löscht ALLE tiere von ein Art aus einem Zoo

DELETE TOP (1) FROM ZooAnimal WHERE ZooId = 2 AND AnimalId = 6;----löscht NUR EINE tiere von ein Art aus einem Zoo
SELECT *FROM ZooAnimal WHERE ZooId = 2 AND AnimalId = 6;

--Beispiel für ShowSelectedAssociatedAnimalInTextBox
SELECT Name FROM ZooAnimal INNER JOIN Animal ON ZooAnimal.AnimalId = Animal.Id WHERE Animal.Id = 5