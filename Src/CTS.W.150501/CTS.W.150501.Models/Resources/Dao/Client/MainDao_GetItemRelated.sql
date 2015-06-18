
select * from [MAItems]
where [ItemCd] != @ItemCd and [CategoryCd] = @CategoryCd
and [LocaleCd] = @LocaleCd
and [DeleteFlag] = 0
order by UpdateDate	desc	


