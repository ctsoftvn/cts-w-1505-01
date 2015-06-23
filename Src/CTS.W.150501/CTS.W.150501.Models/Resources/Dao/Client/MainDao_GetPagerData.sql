SELECT
	mi.ItemCd,
	mi.ItemName,
	mi.LinkName,
	mi.FileCd
FROM [MAItems] mi
WHERE
	mi.LocaleCd = @LocaleCd
	AND (mi.CategoryCd = @CategoryCd OR @CategoryCd = '')
	AND mi.DeleteFlag = 0
ORDER BY
	mi.SortKey ASC