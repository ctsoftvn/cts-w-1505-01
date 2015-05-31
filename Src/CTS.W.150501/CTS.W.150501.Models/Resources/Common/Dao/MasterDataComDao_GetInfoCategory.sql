SELECT
	*
FROM [MACategories]
WHERE
	[LocaleCd] = @LocaleCd
	AND [CategoryCd] = @CategoryCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)