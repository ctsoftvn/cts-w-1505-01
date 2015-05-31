SELECT
    [CategoryCd] AS [Key],
	[CategoryName] AS [Value]
FROM [MACategories]
WHERE
	[LocaleCd] = @LocaleCd
    AND [CategoryCd] NOT IN (@SkipCodes)
    AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)
ORDER BY
    [SortKey] ASC