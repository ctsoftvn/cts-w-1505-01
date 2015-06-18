SELECT
    mi.LocaleCd,
	al.LocaleName,
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
	cd.CodeName AS DeleteFlagName,
	se.MetaTitle,
	se.MetaDesc,
	se.MetaKeys
FROM [MAItems] mi
	LEFT OUTER JOIN [APLocales] al
		ON (al.LocaleCd = mi.LocaleCd
			AND al.AppCd = @CdAppCdCln)
	LEFT OUTER JOIN [MACategories] mc
		ON (mc.LocaleCd = @ContextLocale
			AND mc.CategoryCd = mi.CategoryCd)
	LEFT OUTER JOIN [MACodes] cd
		ON (cd.LocaleCd = @ContextLocale
			AND cd.CodeGroupCd = @GrpCdDeleteFlag
			AND CAST(cd.CodeCd AS BIT) = mi.DeleteFlag)
	LEFT OUTER JOIN [APSEOInfos] se
		ON (se.LocaleCd = mi.LocaleCd
			AND se.SEOCd = mi.ItemCd
			AND se.GroupCd = @GrpSeoMaItems)
WHERE
	(mi.LocaleCd = @LocaleCd OR @LocaleCd = '')
	AND (mi.ItemCd LIKE @ItemCd + '%' OR @ItemCd = '')
	AND (mi.ItemName LIKE '%' + @ItemName + '%'
		OR mi.SearchName LIKE '%' + @ItemName + '%'
		OR @ItemName = '')
	AND (mi.LinkName LIKE '%' + @LinkName + '%' OR @LinkName = '')
	AND (mi.CategoryCd = @CategoryCd OR @CategoryCd = '')
	AND (mi.DeleteFlag = @DeleteFlag OR @DeleteFlag IS NULL)
ORDER BY
	\*OrderByClause*\,
	al.SortKey ASC,
	mi.LocaleCd ASC,
	mi.SortKey ASC