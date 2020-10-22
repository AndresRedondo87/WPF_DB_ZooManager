


            --/// Um SQL Abfragen zu machen: rechte Maus auf unsere Datenverbindung und "Neue Abfrage" auswählen.
            --/// Das offnet uns eine neue SQL Query.

-- SELECTS INTTRO UND INNER JOINs
SELECT * FROM Animal;
SELECT * FROM Zoo;

-- sehen welche Animals der Zoo mit ID 1 hat:
SELECT a.Name FROM Animal a INNER JOIN ZooAnimal za on a.Id = za.AnimalId 
WHERE za.ZooId = 1