SELECT p.Name, c.Name
FROM Products p
LEFT JOIN CategoryProduct cp
	ON p.ID = cp.ProductId
LEFT JOIN Categories c
	ON cp.CategoryId = c.ID
ORDER BY p.Name;