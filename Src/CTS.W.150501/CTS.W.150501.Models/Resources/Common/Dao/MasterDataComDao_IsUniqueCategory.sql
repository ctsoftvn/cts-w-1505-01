SELECT
	COUNT(*)
FROM [MACategories]
WHERE
	[CategoryCd] <> @CategoryCd
	AND [LinkName] = @LinkName