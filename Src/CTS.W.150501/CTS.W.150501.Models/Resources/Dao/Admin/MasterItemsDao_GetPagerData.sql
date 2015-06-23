SELECT
    mi.LocaleCd,
	cd1.CodeName AS LocaleName,
	mi.ItemCd,
	mi.ItemName,
	mi.LinkName,
	mi.CategoryCd,
	mc.CategoryName,
	mi.FileCd,
	mi.Notes,
	mi.SortKey,
	mi.VersionNo,
	mi.DeleteFlag,
	cd2.CodeName AS DeleteFlagName,
	se.MetaTitle,
	se.MetaDesc,
	se.MetaKeys
FROM [MAItems] mi
	INNER JOIN [MACategories] mc
		ON (mc.LocaleCd = @ContextLocale
			AND mc.CategoryCd = mi.CategoryCd
			AND mc.DeleteFlag = 0)
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mi.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mi.DeleteFlag)
	LEFT OUTER JOIN [APSEOInfos] se
		ON (se.LocaleCd = mi.LocaleCd
			AND se.SEOCd = mi.ItemCd
			AND se.GroupCd = @GrpSeoMaItems)
WHERE
	(mi.LocaleCd = @LocaleCd OR @LocaleCd = '')
	AND (mi.ItemName LIKE '%' + @ItemName + '%'
		OR mi.SearchName LIKE '%' + @ItemName + '%'
		OR @ItemName = '')
	AND (mi.LinkName LIKE '%' + @LinkName + '%' OR @LinkName = '')
	AND (mi.CategoryCd = @CategoryCd OR @CategoryCd = '')
	AND (mi.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mi.SortKey ASC,
	cd1.SortKey ASC
	