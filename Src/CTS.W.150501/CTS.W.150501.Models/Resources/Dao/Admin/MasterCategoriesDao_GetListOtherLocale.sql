SELECT
    *
FROM [MACategories]
WHERE
	[LocaleCd] != @LocaleCd
	AND [CategoryCd] = @CategoryCd