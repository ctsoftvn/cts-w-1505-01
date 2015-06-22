UPDATE [MAItems]
SET
	[ItemName] = @ItemName,
	[SearchName] = @SearchName,
	[LinkName] = @LinkName,
	[CategoryCd] = @CategoryCd,
	[FileCd] = @FileCd,
	[Notes] = @Notes,
	[SortKey] = @SortKey,
	[VersionNo] = [VersionNo] + 1,
	[UpdateUser] = @UpdateUser,
	[UpdateDate] = @UpdateDate,
	[DeleteFlag] = @DeleteFlag
WHERE
	[LocaleCd] = @LocaleCd
	AND [ItemCd] = @ItemCd