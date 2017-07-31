-- SOLUTION 1
UPDATE Requests
SET Status = 'CLOSED'
FROM Apartments, Buildings
WHERE Requests.AptID = Apartments.AptID
AND Apartments.BuilidingID = Buildings.BuilidingID
AND Requests.Status != 'CLOSED'
AND Buildings.BuilidingID = 1;

-- SOLUTION 2
UPDATE Requests
SET Status = 'CLOSED'
WHERE AptID IN (
    SELECT Apartments.RequestID
    FROM Requests
    JOIN Apartments USING (AptID)
    WHERE Requests.Status != 'CLOSED' AND Apartments.BuilidingID = 1
);