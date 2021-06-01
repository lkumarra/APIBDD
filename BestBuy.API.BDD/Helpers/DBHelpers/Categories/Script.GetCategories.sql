SELECT 
[categories].[id], 
[categories].[name],
Cast([categories].[createdAt] as varchar) createdAt,
Cast([categories].[updatedAt] as varchar) updatedAt
from categories 
ORDER BY [categories].[createdAt] 
ASC LIMIT 10