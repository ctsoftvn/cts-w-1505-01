
select * from [MAItems]
where [CategoryCd] = @CategoryCd OR @CategoryCd = '' 
and [LocaleCd] = @LocaleCd
and [DeleteFlag] = 0
order by UpdateDate	desc	 

select * from [MACategories]
where [LinkName] = @LinkName

