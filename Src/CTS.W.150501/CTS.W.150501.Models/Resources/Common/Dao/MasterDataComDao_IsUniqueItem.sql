SELECT
	COUNT(*)
FROM [MAItems]
WHERE
	[ItemCd] <> @ItemCd
	AND [LinkName] = @LinkName