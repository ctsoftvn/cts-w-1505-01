SELECT
	*
FROM [MAItems]
WHERE
	[ItemCd] <> @ItemCd
	AND [LinkName] = @LinkName