
select * from [MAItems]
where [ItemCd] = @ItemCd
and [LocaleCd] = @LocaleCd
and [DeleteFlag] = 0
order by UpdateDate	desc	

select * from [MAItems]
where [LinkName] = @LinkName

