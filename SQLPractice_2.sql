USE AdventureWorks2019
GO

  
--1.
SELECT COUNT(*) AS "Total Number"
FROM Production.Product;

--2. 
SELECT COUNT(*) AS "Total Number With Sub"
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL;

--3.
SELECT ProductSubcategoryID, COUNT(*) AS "CountedProducts"
FROM Production.Product
GROUP BY ProductSubcategoryID
HAVING ProductSubcategoryID IS NOT NULL;

--4.  
SELECT COUNT(*) AS "Total Number Without Sub"
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

--5.
SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
GROUP BY ProductID;

--6. 
SELECT ProductID, LocationID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID, LocationID
HAVING SUM(Quantity) < 100;

--7. 
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;

--8. 
SELECT ProductID, AVG(Quantity) AS Average
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID;

--9. 
SELECT Shelf, AVG(Quantity) AS AvgByShelf
FROM Production.ProductInventory
GROUP BY Shelf;

--10. 
SELECT Shelf, AVG(Quantity) AS AvgByShelf
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY Shelf;

--11. 
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE (Color IS NOT NULL) AND (Class IS NOT NULL)
GROUP BY Color, Class;

--12.
SELECT pc.Name AS Country, ps.Name AS Province
FROM Person.CountryRegion pc JOIN Person.StateProvince ps 
ON pc.CountryRegionCode = ps.CountryRegionCode;

--13.
SELECT pc.Name AS Country, ps.Name AS Province
FROM Person.CountryRegion pc JOIN Person.StateProvince ps 
ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.Name IN ('Germany', 'Canada');

USE Northwind
GO

--14.
SELECT p.ProductID, p.ProductName, o.OrderID, o.OrderDate
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate > '1998-02-16 00:00:00.000'

--15. 
SELECT TOP 5 ShipPostalCode, COUNT(ShipPostalCode) AS CountAll
FROM Orders
GROUP BY ShipPostalCode
ORDER BY CountAll DESC;

--16. 
SELECT TOP 5 ShipPostalCode, COUNT(ShipPostalCode) AS CountAll
FROM Orders
WHERE OrderDate > '1998-02-16 00:00:00.000'
GROUP BY ShipPostalCode
ORDER BY CountAll DESC;

--17.
SELECT City, COUNT(City) AS NumOfCustomers
FROM Customers
GROUP BY City;

--18. 
SELECT City, COUNT(City) AS NumOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(City) > 2;

--19. 
SELECT c.ContactName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE OrderDate > '1998-01-01 00:00:00.000'
ORDER By OrderDate;

--20. 
SELECT c.ContactName, MAX(o.OrderDate) AS [Most Recent]
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName;

--21. 
SELECT c.ContactName, SUM(od.Quantity) AS "Total Num Of Products"
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName
ORDER BY "Total Num Of Products" DESC;

--22. 
SELECT c.CustomerID, SUM(od.Quantity) AS "Total Num Of Products"
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity) > 100
ORDER BY "Total Num Of Products" DESC;

--23.
SELECT su.CompanyName AS "Supplier Company Name", sh.CompanyName AS "Shipping Company Name"
FROM Suppliers su CROSS JOIN Shippers sh;

--24.
SELECT LEFT(o.OrderDate, 11) AS "Date", p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderDate;

--25. 
SELECT e1.FirstName + ' ' + e1.LastName AS Name_1, e2.FirstName + ' ' + e2.LastName AS Name_2, e1.Title AS Title
FROM Employees e1 INNER JOIN Employees e2 ON e1.Title = e2.Title AND (e1.FirstName + ' ' + e1.LastName) < (e2.FirstName + ' ' + e2.LastName)
WHERE (e1.FirstName + ' ' + e1.LastName) <> (e2.FirstName + ' ' + e2.LastName)
ORDER BY Name_1;

--26. 
SELECT e2.FirstName + ' ' + e2.LastName AS Managers, COUNT(e1.ReportsTo) AS Employees
FROM Employees e1 INNER JOIN Employees e2 ON e1.ReportsTo = e2.EmployeeID
GROUP BY e2.FirstName + ' ' + e2.LastName
HAVING COUNT(e1.ReportsTo) > 2;

--27. 
SELECT City, CompanyName AS Name, ContactName AS "Contact Name", 'Customer' AS Type
FROM Customers
UNION
SELECT City, CompanyName AS Name, ContactName AS "Contact Name", 'Suppliers' AS Type
FROM Suppliers;
