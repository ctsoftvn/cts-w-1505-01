UPDATE [MACategories]
SET
	[CategoryName] = @ItemName,
	[SearchName] = @SearchName,
	[LinkName] = @LinkName,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [CategoryCd] = @CategoryCd