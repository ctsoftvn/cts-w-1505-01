SELECT
    mc.LocaleCd,
	cd1.CodeName AS LocaleName,
	mc.CategoryCd,
	mc.CategoryName,
	mc.SearchName,
	mc.LinkName,
	mc.SortKey,
	mc.VersionNo,
	mc.DeleteFlag,
	cd2.CodeName AS DeleteFlagName,
	se.MetaTitle,
	se.MetaDesc,
	se.MetaKeys
FROM [MACategories] mc
	LEFT OUTER JOIN [MACodes] cd1
		ON (cd1.LocaleCd = @ContextLocale
			AND cd1.CodeGroupCd = @GrpCdLocales
			AND cd1.CodeCd = mc.LocaleCd)
	LEFT OUTER JOIN [MACodes] cd2
		ON (cd2.LocaleCd = @ContextLocale
			AND cd2.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd2.CodeCd AS BIT) = mc.DeleteFlag)
	LEFT OUTER JOIN [APSEOInfos] se
		ON (se.LocaleCd = mc.LocaleCd
			AND se.SEOCd = mc.CategoryCd
			AND se.GroupCd = @GrpSeoMaCategories)
WHERE
	(mc.LocaleCd = @LocaleCd OR @LocaleCd = '')
	AND (mc.CategoryName LIKE '%' + @CategoryName + '%'
		OR mc.SearchName LIKE '%' + @CategoryName + '%'
		OR @CategoryName = '')
	AND (mc.LinkName LIKE '%' + @LinkName + '%' OR @LinkName = '')
	AND (mc.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	mc.SortKey ASC,
	cd1.SortKey ASC