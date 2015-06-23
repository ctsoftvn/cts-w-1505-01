SELECT
	mi.ItemCd,
	mi.ItemName,
	mi.LinkName,
	mi.FileCd
FROM [MAItems] mi
INNER JOIN [MACategories] mc
		ON (mc.LocaleCd = @LocaleCd
			AND mc.CategoryCd = mi.CategoryCd
			AND mc.DeleteFlag = 0)
WHERE
	mi.LocaleCd = @LocaleCd
	AND (mi.CategoryCd = @CategoryCd OR @CategoryCd = '')
	AND mi.DeleteFlag = 0
ORDER BY
	mi.SortKey ASC