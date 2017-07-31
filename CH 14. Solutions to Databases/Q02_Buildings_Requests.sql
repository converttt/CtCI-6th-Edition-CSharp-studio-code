# SOLUTION 1
SELECT Buildings.*, COUNT(Requests.RequestID) AS ReqNum
FROM Buildings
LEFT JOIN Apartments USING (BuilidingID)
LEFT JOIN Requests ON (Requests.AptID = Apartments.AptID AND Requests.Status = 'OPEN')
GROUP BY Buildings.BuilidingID
ORDER BY ReqNum DESC;

#SOLUTION 2
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