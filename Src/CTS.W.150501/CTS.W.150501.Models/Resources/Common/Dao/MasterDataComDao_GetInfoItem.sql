SELECT
	*
FROM [MAItems]
WHERE
	[LocaleCd] = @LocaleCd
	AND [ItemCd] = @ItemCd
	AND ([DeleteFlag] = 0 OR @IgnoreDeleteFlag = 1)