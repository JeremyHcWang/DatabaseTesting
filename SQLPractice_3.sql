USE NorthWind
GO

--1. 
SELECT DISTINCT City 
FROM Employees
WHERE City IN (SELECT City FROM Customers);

--2a. 
SELECT DISTINCT City 
FROM Customers
WHERE City NOT IN (SELECT City FROM Employees);

--2b. 
SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.City = e.City
WHERE e.City is NULL;

--3. 
SELECT p.ProductName, SUM(od.Quantity) AS "Total Quantity"
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY "Total Quantity" DESC;

--4. 
SELECT c.City, COUNT(DISTINCT od.ProductID) AS TotalProduct
FROM Customers c JOIN Orders o ON c.City = o.ShipCity
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY TotalProduct DESC;

--5. 
SELECT City, COUNT(CustomerID) AS NumOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2
ORDER BY NumOfCustomers DESC;

--6.  
SELECT c.City, COUNT(DISTINCT od.ProductID) AS TotalProduct
FROM Customers c JOIN Orders o ON c.City = o.ShipCity
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2
ORDER BY TotalProduct DESC;

--7. 
SELECT DISTINCT c.CustomerID, c.CompanyName, c.City, o.ShipCity
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.city <> o.ShipCity;

--8. 
DECLARE @PopularProducts TABLE (ProductID Int, Frequency Int, AveragePrice Float)
INSERT INTO @PopularProducts 
    SELECT TOP 5 od.ProductID, COUNT(od.ProductID) AS Frequency, AVG(od.UnitPrice) AS AveragePrice
    FROM [Order Details] od
    GROUP BY od.ProductID
    ORDER BY Frequency DESC

SELECT * FROM @PopularProducts

---SELECT p.ProductID, p.AveragePrice, c.City, p.Frequency AS QuantityOrdered
---FROM @PopularProducts p JOIN Orders o ON p.OrderID = o.OrderID
---JOIN Customers c ON o.CustomerID = c.CustomerID 

--9a. 
SELECT DISTINCT City
FROM Employees
WHERE City NOT IN (
    SELECT DISTINCT City
    FROM Customers
);

--9b.
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL;

--10. I'm having trouble getting the right results for this question

--11. This can be achieved by grouping by all the column names and deleting rows with count larger than 1 recursively until count of row is 1.
