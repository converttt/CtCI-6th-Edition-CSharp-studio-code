-- Open Requests: Write a SQL query to get a list of all buildings and the number of open requests
-- (Requests in which status equals 'Open').

-- SOLUTION 1
SELECT Buildings.*, COUNT(Requests.RequestID) AS ReqNum
FROM Buildings
LEFT JOIN Apartments USING (BuilidingID)
LEFT JOIN Requests ON (Requests.AptID = Apartments.AptID AND Requests.Status = 'OPEN')
GROUP BY Buildings.BuilidingID
ORDER BY ReqNum DESC;

-- SOLUTION 2
SELECT Buildings.*, COUNT(Requests.RequestID) AS ReqNum
FROM Buildings
LEFT JOIN Apartments USING (BuilidingID)
LEFT JOIN (
    SELECT *
    FROM Requests
    WHERE Status = 'OPEN'
) AS Requests USING (AptID)
GROUP BY Buildings.BuilidingID
ORDER BY ReqNum DESC;

-- SOLUTION 3
SELECT Buildings.*, COALESCE(tmp.Requests, 0) AS Requests
FROM Buildings
LEFT JOIN (
    SELECT Apartments.BuilidingID, count(*) AS Requests
    FROM Apartments
    LEFT JOIN Requests using(AptID)
    WHERE Requests.Status = 'OPEN'
    GROUP BY Apartments.BuilidingID
) AS tmp using(BuilidingID)
ORDER BY Requests DESC